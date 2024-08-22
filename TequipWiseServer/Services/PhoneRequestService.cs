using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TequipWiseServer.Data;
using TequipWiseServer.DTO;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;
using User.Managmenet.Service.Models;
using User.Managmenet.Service.Services;

namespace TequipWiseServer.Services
{
    public class PhoneRequestService : IPhoneRequest
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAuthentication _authService;
        private readonly IEMailService _emailService;
        private readonly UserManager<ApplicationUser> _userManager;
        public PhoneRequestService(AppDbContext dbContext, IMapper mapper, IAuthentication authService, IEMailService emailService, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _authService = authService;
            _emailService = emailService;
            _userManager = userManager;
        }
        public string FixedemailLink = "http://localhost:4200/";



        public async Task<IActionResult> PassPhoneRequest(PhoneRequest request)
        {
            // Get the authenticated user details
            var userResult = await _authService.GetAuthenticatedUserAsync();

            if (userResult is UnauthorizedResult)
            {
                return new ObjectResult(new Response { Status = "Unauthorized", Message = "Authenticated user not retrieved!" });
            }

            var okResult = userResult as OkObjectResult;
            if (okResult == null || okResult.Value == null)
            {
                return new ObjectResult(new Response { Status = "Unauthorized", Message = "Authenticated user not retrieved!" });
            }

            var userDetails = okResult.Value as UserDetailsDTO;
            if (userDetails == null || userDetails.Department == null || userDetails.Department.Manager == null)
            {
                return new ObjectResult(new Response { Status = "Error", Message = "Authenticated user information not retrieved!" });
            }

            // Assign the request to the authenticated user
            request.UserId = userDetails.Id;
            // Set the actual date
            request.RequestDate = DateTime.Now;

            _dbContext.PhoneRequests.Add(request);
            await _dbContext.SaveChangesAsync();

            await SendEmailForApprovalAsync(userDetails);

            return new OkObjectResult(new Response { Status = "Success", Message = "Request passed successfully!" });
        }

        private async Task SendEmailForApprovalAsync(UserDetailsDTO userDetails)
        {
            var haveApprover = userDetails.ApproverActive;
            var haveBackupApprover = userDetails.ManagerBackupApproverActive;

            if (haveApprover == true)
            {
                var approverEmail = userDetails.ApproverEmail;
                if (string.IsNullOrEmpty(approverEmail))
                {
                    throw new Exception("Approver email is missing.");
                }

                var approver = await _userManager.FindByEmailAsync(approverEmail);
                if (approver != null)
                {
                    await SendEmailAsync(approver.Email, "PhoneRequestConfirmation");
                }
            }
            else if (haveBackupApprover == true)
            {
                var backupApproverEmail = userDetails.ManagerBackupApproverEmail;
                if (string.IsNullOrEmpty(backupApproverEmail))
                {
                    throw new Exception("Backup Approver email is missing.");
                }

                var manager = await _userManager.FindByEmailAsync(backupApproverEmail);
                if (manager != null)
                {
                    await SendEmailAsync(manager.Email, "PhoneRequestConfirmation");
                }
            }
            else
            {
                var deptmanagerEmail = userDetails.ManagerEmail;
                if (string.IsNullOrEmpty(deptmanagerEmail))
                {
                    throw new Exception("Department manager's email is missing.");
                }

                var manager = await _userManager.FindByEmailAsync(deptmanagerEmail);
                if (manager != null)
                {
                    await SendEmailAsync(manager.Email, "PhoneRequestConfirmation");
                }
            }
        }

        private async Task SendEmailAsync(string email, string linkAction)
        {
            var deptmangLink = FixedemailLink + linkAction;
            var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "RequestApprovalTemplate.html");
            var emailTemplate = await System.IO.File.ReadAllTextAsync(emailTemplatePath);
            var emailContent = emailTemplate.Replace("{{resetLink}}", deptmangLink);

            var message = new Message(new string[] { email }, "Equipment Request Confirmation Link", emailContent, isHtml: true);
            _emailService.SendEmail(message);
        }




        async public Task<IEnumerable<PhoneRequestDTO>> GetRequestsByUserIdAsync(string userId)
        {
            var requests = await _dbContext.PhoneRequests
       .Where(r => r.UserId == userId)
       .OrderByDescending(r => r.RequestDate)
       .Include(r => r.User)
       .Include(r=>r.HR)
       .Include(r=>r.DeparManag)
       .ToListAsync();

            return _mapper.Map<IEnumerable<PhoneRequestDTO>>(requests);
        }

       async public Task<IEnumerable<PhoneRequestDTO>> GetRequestsForDepartmentManagerAsync(string managerId)
        {

            var requests = await _dbContext.PhoneRequests
                                             .Where(r => r.User.Department.ManagerId == managerId ||
                                             r.User.Department.Manager.BackupaproverId == managerId)
                                            .OrderByDescending(r => r.RequestDate)
                                            .Include(r => r.User)
                                            .Include(r => r.HR)
                                            .Include(r => r.DeparManag)
                                            .ToListAsync();
            return _mapper.Map<IEnumerable<PhoneRequestDTO>>(requests);
        }

       async public Task<IEnumerable<PhoneRequestDTO>> GetRequestsForPlantITApproverAsync(string Itapproverid)
        {
            // Step 1: Find the plant IDs where the user is the IT approver or the backup IT approver
            var plantIds = await _dbContext.Plants
                                           .Where(p => p.ITApproverId == Itapproverid ||
                                                       p.ItApprover.BackupaproverId == Itapproverid)
                                           .Select(p => p.PlantNumber)
                                           .ToListAsync();

            // Debug: Log or inspect plant IDs
            Console.WriteLine("Plant IDs where the user is IT approver or backup IT approver:");
            foreach (var id in plantIds)
            {
                Console.WriteLine($"Plant ID: {id}");
            }

            // Check if plantIds is empty
            if (!plantIds.Any())
            {
                Console.WriteLine("No plant IDs found for the given IT approver or backup IT approver.");
                return Enumerable.Empty<PhoneRequestDTO>();
            }

            // Step 2: Get the requests for those plants where at least one subrequest has deptmangestatus as true
            var requests = await _dbContext.PhoneRequests
                                         .Where(r => r.User.plantId.HasValue && plantIds.Contains(r.User.plantId.Value) && r.HRconfirmSatuts==true) 
                                         .OrderByDescending(r => r.RequestDate)
                                         .Include(r => r.User)
                                         .Include(r => r.HR)
                                         .Include(r => r.DeparManag)
                                         .ToListAsync();

            // Debug: Log or inspect requests count
            Console.WriteLine($"Total requests found: {requests.Count}");
            foreach (var request in requests)
            {
                Console.WriteLine($"Request ID: {request.PhoneRequestId}, Plant ID: {request.User.plantId}");
            }

            return _mapper.Map<IEnumerable<PhoneRequestDTO>>(requests);
        }

      async  public Task<IEnumerable<PhoneRequestDTO>> GetRequestsForPlantHRApproverAsync(string HRapproverid)
        {
            // Step 1: Find the plant IDs where the user is the IT approver or the backup IT approver
            var plantIds = await _dbContext.Plants
                                           .Where(p => p.HRApproverId == HRapproverid ||
                                                       p.HRApprover.BackupaproverId == HRapproverid)
                                           .Select(p => p.PlantNumber)
                                           .ToListAsync();

            // Debug: Log or inspect plant IDs
            Console.WriteLine("Plant IDs where the user is IT approver or backup IT approver:");
            foreach (var id in plantIds)
            {
                Console.WriteLine($"Plant ID: {id}");
            }

            // Check if plantIds is empty
            if (!plantIds.Any())
            {
                Console.WriteLine("No plant IDs found for the given IT approver or backup IT approver.");
                return Enumerable.Empty<PhoneRequestDTO>();
            }

            // Step 2: Get the requests for those plants where at least one subrequest has deptmangestatus as true
            var requests = await _dbContext.PhoneRequests
                                         .Where(r => r.User.plantId.HasValue && plantIds.Contains(r.User.plantId.Value) && r.DepartmangconfirmStatus == true)
                                         .OrderByDescending(r => r.RequestDate)
                                         .Include(r => r.User)
                                         .Include(r => r.HR)
                                         .Include(r => r.DeparManag)
                                         .ToListAsync();

            // Debug: Log or inspect requests count
            Console.WriteLine($"Total requests found: {requests.Count}");
            foreach (var request in requests)
            {
                Console.WriteLine($"Request ID: {request.PhoneRequestId}, Plant ID: {request.User.plantId}");
            }

            return _mapper.Map<IEnumerable<PhoneRequestDTO>>(requests);
        }

        public async Task<IActionResult> UpdatePhoneRequest(int requestId, PhoneRequest updatedRequest)
        {
            // Find the existing phone request in the database
            var existingRequest = await _dbContext.PhoneRequests.FindAsync(requestId);

            if (existingRequest == null)
            {
                return new NotFoundObjectResult(new Response { Status = "Error", Message = "Request not found." });
            }

            // Get the authenticated user
            var userResult = await _authService.GetAuthenticatedUserAsync();

            if (userResult is UnauthorizedResult)
            {
                return new ObjectResult(new Response { Status = "Unauthorized", Message = "Authenticated user not retrieved!" });
            }

            var okResult = userResult as OkObjectResult;
            if (okResult == null || okResult.Value == null)
            {
                return new ObjectResult(new Response { Status = "Unauthorized", Message = "Authenticated user not retrieved!" });
            }

            var userDetails = okResult.Value as UserDetailsDTO;
            if (userDetails == null || userDetails.Department == null || userDetails.Department.Manager == null)
            {
                return new ObjectResult(new Response { Status = "Error", Message = "Authenticated user information not retrieved!" });
            }

            // Check for changes in Department Manager confirmation status
            if (updatedRequest.DepartmangconfirmStatus != existingRequest.DepartmangconfirmStatus)
            {
                updatedRequest.DepartmangconfirmedAt = DateTime.Now;
                updatedRequest.deptManagId = userDetails.Id;

                var HREmail = existingRequest?.User?.Plant?.HRApprover?.Email;
                Console.WriteLine("==================" + HREmail);
                if (!string.IsNullOrEmpty(HREmail))
                {
                    var rejectionLink = FixedemailLink + "PhoneRequestConfirmation";
                    var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "RequestApprovalTemplate.html");
                    var emailTemplate = await System.IO.File.ReadAllTextAsync(emailTemplatePath);
                    var emailContent = emailTemplate.Replace("{{resetLink}}", rejectionLink);
                    var message = new Message(new[] { HREmail }, "Phone Request Approval", emailContent, isHtml: true);
                    _emailService.SendEmail(message);
                }
            }

            // Check for changes in HR confirmation status
            if (updatedRequest.HRconfirmSatuts != existingRequest.HRconfirmSatuts)
            {
                updatedRequest.HRconfirmedAt = DateTime.Now;
                updatedRequest.HRId = userDetails.Id;

                var ItEmail = existingRequest?.User?.Plant?.ItApprover?.Email;
                if (!string.IsNullOrEmpty(ItEmail))
                {
                    var rejectionLink = FixedemailLink + "PhoneRequestConfirmation";
                    var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "RequestApprovalTemplate.html");
                    var emailTemplate = await System.IO.File.ReadAllTextAsync(emailTemplatePath);
                    var emailContent = emailTemplate.Replace("{{resetLink}}", rejectionLink);
                    var message = new Message(new[] { ItEmail }, "Phone Request Approval", emailContent, isHtml: true);
                    _emailService.SendEmail(message);
                }
            }

            // Check for changes in IT confirmation status
            if (updatedRequest.ITconfirmSatuts != existingRequest.ITconfirmSatuts)
            {
                updatedRequest.ITconfirmedAt = DateTime.Now;
                updatedRequest.itId = userDetails.Id;

                if (updatedRequest.ITconfirmSatuts == true)
                {
                    updatedRequest.RequestStatus = true;

                    var Useremail = existingRequest?.User?.Email;
                    if (!string.IsNullOrEmpty(Useremail))
                    {
                        var rejectionLink = FixedemailLink + "PhoneRequestConfirmation";
                        var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "EmailRequestConfirmed.html");
                        var emailTemplate = await System.IO.File.ReadAllTextAsync(emailTemplatePath);
                        var emailContent = emailTemplate
                            .Replace("{{resetLink}}", rejectionLink)
                            .Replace("{{TeNum}}", existingRequest.User.TeNum);
                        var message = new Message(new[] { Useremail }, "Phone Request Approval", emailContent, isHtml: true);
                        _emailService.SendEmail(message);
                    }
                }
            }

            // Change the global status of the request to false if rejected
            if (updatedRequest.DepartmangconfirmStatus == false || updatedRequest.ITconfirmSatuts == false || updatedRequest.HRconfirmSatuts == false)
            {
                var rejectionLink = FixedemailLink + "PhoneRequestConfirmation";
                var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "RejectionTemplate.html");
                var emailTemplate = await System.IO.File.ReadAllTextAsync(emailTemplatePath);
                var emailContent = emailTemplate
                    .Replace("{{resetLink}}", rejectionLink)
                    .Replace("{{equipment}}", existingRequest.AssetType)
                    .Replace("{{UserName}}", existingRequest.User.TeNum);

                updatedRequest.RequestStatus = false;

                var userEmail = existingRequest.User?.Email;
                if (!string.IsNullOrEmpty(userEmail))
                {
                    var message = new Message(new[] { userEmail }, "Phone Request Rejection", emailContent, isHtml: true);
                    _emailService.SendEmail(message);
                    Console.WriteLine("Rejection email sent to: " + userEmail);
                }
                else
                {
                    Console.WriteLine("User email is null or empty.");
                }

                Console.WriteLine("=================== The sub-request is rejected");
            }

            // Update only the fields that are not null in the updatedRequest object
            _dbContext.Entry(existingRequest).CurrentValues.SetValues(updatedRequest);

            // Save the changes to the database
            await _dbContext.SaveChangesAsync();

            return new OkObjectResult(new Response { Status = "Success", Message = "Request updated successfully." });
        }
        async public Task<PhoneRequest> GetphoneRequestByIdAsync(int phoneRequestId)
        {
            return await _dbContext.PhoneRequests
                               .Include(s => s.DeparManag)
                               .Include(s => s.IT)
                               .Include(s=>s.HR)
                               .Include(u=>u.User)
                               .FirstOrDefaultAsync(s => s.PhoneRequestId == phoneRequestId);
        }


    }
}

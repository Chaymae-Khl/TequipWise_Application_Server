using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TequipWiseServer.Data;
using TequipWiseServer.DTO;
using TequipWiseServer.Helpers;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;
using User.Managmenet.Service.Models;
using User.Managmenet.Service.Services;

namespace TequipWiseServer.Services
{
    public class MaintenanceService : IMaintenance
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAuthentication _authService;
        private readonly IEMailService _emailService;
        private readonly UserManager<ApplicationUser> _userManager;
        public MaintenanceService(AppDbContext dbContext, IMapper mapper, IAuthentication authService, IEMailService emailService, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _authService = authService;
            _emailService = emailService;
            _userManager = userManager;
        }
        public string FixedemailLink = "http://localhost:4200/";

       async public Task<IActionResult> PassMaintenanceRequest(MaintenanceRequest request)
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
            request.itId = userDetails.Id;
            // Set the actual date
            request.RequestDate = DateTime.Now;
            _dbContext.MaintenanceRequests.Add(request);
            await _dbContext.SaveChangesAsync();
            var requestUserdetails = await _authService.GetUserByIdAsync(request.UserId);
            Console.WriteLine("=================", request.UserId);

            Console.WriteLine("=================",requestUserdetails?.ManagerEmail);
            var userDeptmangEmail = requestUserdetails?.ManagerEmail;
            if (!string.IsNullOrEmpty(userDeptmangEmail))
            {
                var rejectionLink = FixedemailLink + "maintenanceRequestlist";
                var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "RequestApprovalTemplate.html");
                var emailTemplate = await System.IO.File.ReadAllTextAsync(emailTemplatePath);
                var emailContent = emailTemplate.Replace("{{resetLink}}", rejectionLink);
                var message = new Message(new[] { userDeptmangEmail }, "Maintenance Request Approval", emailContent, isHtml: true);
                _emailService.SendEmail(message);
            }

            return new OkObjectResult(new Response { Status = "Success", Message = "Request passed successfully!" });
        }

        async public Task<IEnumerable<MaintenanceRequestDTO>> GetRequestsForITAsync(string userId)
        {
         
            // Step 1: Find the plant IDs where the user is the IT approver or the backup IT approver
            var plantIds = await _dbContext.Plants
                                           .Where(p => p.ITApproverId == userId ||
                                                       p.ItApprover.BackupaproverId == userId)
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
                return Enumerable.Empty<MaintenanceRequestDTO>();
            }

            // Step 2: Get the requests for those plants where at least one subrequest has deptmangestatus as true
            var requests = await _dbContext.MaintenanceRequests
           .Where(r => r.itId == userId)
            .OrderByDescending(r => r.RequestDate)
           .Include(r => r.User)
           .Include(r => r.Controller)
           .Include(r => r.DeptMnag)
            .Include(r => r.supplier)
           .ToListAsync();
            return _mapper.Map<IEnumerable<MaintenanceRequestDTO>>(requests);
        }
        public async Task<IEnumerable<MaintenanceRequestDTO>> GetRequestsForDepartmentManagerAsync(string managerId)
        {
            var requests = await _dbContext.MaintenanceRequests
                                               .Where(r => ((r.User.Department.ManagerId == managerId ||
                                               r.User.Department.Manager.BackupaproverId == managerId || r.damageTYpe == "Warenty") && r.offer!=null))
                                   .OrderByDescending(r => r.RequestDate)
                                   .Include(r => r.User)
                                   .ThenInclude(rs => rs.SapNumber)
                                   .Include(sb => sb.IT)
                                   .Include(sb => sb.Controller)
                                   .Include(sb => sb.DeptMnag)
                                   .Include(sb => sb.supplier)
                                   .AsNoTracking()
                                   .ToListAsync();
            return _mapper.Map<IEnumerable<MaintenanceRequestDTO>>(requests);
        }

        public async Task<IEnumerable<MaintenanceRequestDTO>> GetRequestsForApproverAsync(string managerId)
        {
            var requests = await _dbContext.MaintenanceRequests
                                      .Where(r => r.User.ManagerId == managerId)
                                   .OrderByDescending(r => r.RequestDate)
                                   .Include(r => r.User)
                                   .ThenInclude(rs => rs.SapNumber)
                                   .Include(sb => sb.IT)
                                   .Include(sb => sb.Controller)
                                   .Include(sb => sb.DeptMnag)
                                   .Include(sb => sb.supplier)
                                   .AsNoTracking()
                                   .ToListAsync();

            return _mapper.Map<IEnumerable<MaintenanceRequestDTO>>(requests);
        }
        public async Task<IEnumerable<MaintenanceRequestDTO>> GetRequestsForSapControllerAsync(string controllerId)
        {
            var requests = await _dbContext.MaintenanceRequests
                                 .Where(r => ((r.User.SapNumber.Idcontroller == controllerId ||
                                              r.User.SapNumber.Controller.BackupaproverId == controllerId) && r.DepartmangconfirmStatus == true))
                                 .OrderByDescending(r => r.RequestDate)
                                  .Include(r => r.User)
                                   .ThenInclude(rs => rs.SapNumber)
                                   .Include(sb => sb.IT)
                                   .Include(sb => sb.Controller)
                                   .Include(sb => sb.DeptMnag)
                                   .Include(sb => sb.supplier)
                                 .AsNoTracking()
                                 .ToListAsync();
            return _mapper.Map<IEnumerable<MaintenanceRequestDTO>>(requests);
        }
        public async Task<IEnumerable<MaintenanceRequestDTO>> GetRequestsForAdminAsync(string controllerId)
        {
            var requests = await _dbContext.MaintenanceRequests
                                           .OrderByDescending(r => r.RequestDate)
                                            .Include(r => r.User)
                                   .ThenInclude(rs => rs.SapNumber)
                                   .Include(sb => sb.IT)
                                   .Include(sb => sb.Controller)
                                   .Include(sb => sb.DeptMnag)
                                   .Include(sb => sb.supplier)
                                           .AsNoTracking()
                                           .ToListAsync();

            return _mapper.Map<IEnumerable<MaintenanceRequestDTO>>(requests);
        }

        public async Task<MaintenanceRequest?> UpdateRequestAsync(int equipmentRequestId, MaintenanceRequest updatedRequest, IFormFile? file)
        {
            // Retrieve the current sub-request details from the database
            var currentSubRequestDetails = await GetRequestByIdAsync(updatedRequest.MaintenanceId);
            if (currentSubRequestDetails == null)
            {
                Console.WriteLine("Request details not found");
                return null;
            }
            // Retrieve the authenticated user info
            var userResult = await _authService.GetAuthenticatedUserAsync();
            var okResult = userResult as OkObjectResult;

            if (okResult?.Value is not UserDetailsDTO userDetails)
            {
                Console.WriteLine("Authenticated user not found");
                return null;
            }
            var Userdetails = await _authService.GetUserByIdAsync(updatedRequest.UserId);
            bool statusChanged = false;
            if (updatedRequest.offer != currentSubRequestDetails.offer)
            {
                var fileUploadHelper = new FileUploadHelper();
                try
                {
                    updatedRequest.offer  = await fileUploadHelper.UploadFileAsync(file);
                }
                catch (ArgumentException ex)
                {
                }
                var requestUserdetails = await _authService.GetUserByIdAsync(updatedRequest.UserId);
                Console.WriteLine("=================", updatedRequest.UserId);

                Console.WriteLine("=================", requestUserdetails?.ManagerEmail);
                var userDeptmangEmail = requestUserdetails?.ManagerEmail;
                if (!string.IsNullOrEmpty(userDeptmangEmail))
                {
                    var rejectionLink = FixedemailLink + "maintenanceRequestlist";
                    var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "RequestApprovalTemplate.html");
                    var emailTemplate = await System.IO.File.ReadAllTextAsync(emailTemplatePath);
                    var emailContent = emailTemplate.Replace("{{resetLink}}", rejectionLink);
                    var message = new Message(new[] { userDeptmangEmail }, "Maintenance Request Approval", emailContent, isHtml: true);
                    _emailService.SendEmail(message);
                }
            }
                // Check if 'DepartmangconfirmStatus' has been modified
                if (updatedRequest.DepartmangconfirmStatus != currentSubRequestDetails.DepartmangconfirmStatus)
            {
                updatedRequest.deptManagId = userDetails.Id;
                updatedRequest.DepartmangconfirmedAt = DateTime.Now;
                statusChanged = true;

                // Send email to IT Approver or Backup when the manager approves
                await SendEmailAsync(Userdetails, "Manager Approval", "maintenanceRequestlist", "RequestApprovalTemplate.html", "Maintenance Request Confirmation Link");
            }

            // Check if the finance status has been changed
            if (updatedRequest.ControllerconfirmSatuts != currentSubRequestDetails.ControllerconfirmSatuts)
            {
                updatedRequest.ControllerId = userDetails.Id;
                updatedRequest.ControllerconfirmedAt = DateTime.Now;
                statusChanged = true;
                await SendEmailAsync(Userdetails, "Controller Approval", "maintenanceRequestlist", "RequestApprovalTemplate.html", "Maintenance Request Confirmation Link");
            }

            // Check if PR_Status has been changed
            if (updatedRequest.PR_Status != currentSubRequestDetails.PR_Status)
            {
                updatedRequest.itId = userDetails.Id;
                updatedRequest.ITconfirmedAt = DateTime.Now;

                if (updatedRequest.PR_Status == false)
                {
                    updatedRequest.RequestStatus = false;
                    await SendEmailAsync(Userdetails, "Rejection", "maintenanceRequestlist", "EmailRequestConfirmed.html", "Maintenance Request Rejection");
                    Console.WriteLine("=================== the request is rejected ");
                }
                statusChanged = true;
            }

            // Check if PONum has been changed
            if (updatedRequest.PONum != currentSubRequestDetails.PONum)
            {
                updatedRequest.itId = userDetails.Id;
                updatedRequest.ITconfirmSatuts = true;
                updatedRequest.ITconfirmedAt = DateTime.Now;
                updatedRequest.RequestStatus = true;

                var Useremail = Userdetails.ItApproverEmail;
                if (!string.IsNullOrEmpty(Useremail))
                {
                    var rejectionLink = FixedemailLink + "maintenanceRequestlist";
                    var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "EmailRequestConfirmed.html");
                    var emailTemplate = await System.IO.File.ReadAllTextAsync(emailTemplatePath);
                    var emailContent = emailTemplate
                        .Replace("{{resetLink}}", rejectionLink)
                        .Replace("{{TeNum}}", Userdetails.ItApproverName);
                    var message = new Message(new[] { Useremail }, "Maintenance Request Approval", emailContent, isHtml: true);
                    _emailService.SendEmail(message);
                }
                statusChanged = true;
            }

            // Change the global status of the request to false if rejected
            if (updatedRequest.DepartmangconfirmStatus == false || updatedRequest.ITconfirmSatuts == false || updatedRequest.ControllerconfirmSatuts == false)
            {
                var rejectionLink = FixedemailLink + "maintenanceRequestlist";
                var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "RejectionTemplate.html");
                var emailTemplate = await System.IO.File.ReadAllTextAsync(emailTemplatePath);
                var emailContent = emailTemplate
                    .Replace("{{resetLink}}", rejectionLink)
                    .Replace("{{UserName}}", Userdetails.ItApproverName);

                updatedRequest.RequestStatus = false;

                var userEmail = Userdetails.Email;
                if (!string.IsNullOrEmpty(userEmail))
                {
                    var message = new Message(new[] { userEmail }, "Maintenance Request Rejection", emailContent, isHtml: true);
                    _emailService.SendEmail(message);
                    Console.WriteLine("Rejection email sent to: " + userEmail);
                }
                else
                {
                    Console.WriteLine("User email is null or empty.");
                }

                Console.WriteLine("=================== the sub-request is rejected ");
            }

            // Update only the properties that are not null in updatedSubRequest
            var properties = typeof(MaintenanceRequest).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var newValue = property.GetValue(updatedRequest);
                if (newValue != null)
                {
                    property.SetValue(currentSubRequestDetails, newValue);
                    statusChanged = true;
                }
            }

            if (statusChanged)
            {
                await _dbContext.SaveChangesAsync();
            }

            return currentSubRequestDetails;
        }

        private async Task SendEmailAsync(UserDetailsDTO equipmentRequest, string emailType, string linkPath, string templateName, string subject)
        {
            var itApproverEmail = equipmentRequest.ItApproverEmail;
            var itApproverBackup = equipmentRequest.ManagerBackupApproverEmail;

            if (itApproverEmail == null)
            {
                Console.WriteLine("IT Approver email is null or empty.");
            }
            else
            {
                Console.WriteLine("IT Approver Email: " + itApproverEmail);
            }

            if (itApproverBackup == null)
            {
                Console.WriteLine("IT Approver Backup email is null or empty.");
            }
            else
            {
                Console.WriteLine("IT Approver Backup Email: " + itApproverBackup);
            }

            if (!string.IsNullOrEmpty(itApproverEmail))
            {
                var itApproverLink = FixedemailLink + linkPath;
                var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", templateName);
                var emailTemplate = await System.IO.File.ReadAllTextAsync(emailTemplatePath);
                var emailContent = emailTemplate
                    .Replace("{{resetLink}}", itApproverLink)
                    .Replace("{{TeNum}}", equipmentRequest.TeNum);

                if (equipmentRequest.backupActive == true && !string.IsNullOrEmpty(itApproverBackup))
                {
                    var message = new Message(new[] { itApproverBackup }, subject, emailContent, isHtml: true);
                    _emailService.SendEmail(message);
                }
                else
                {
                    var message = new Message(new[] { itApproverEmail }, subject, emailContent, isHtml: true);
                    _emailService.SendEmail(message);
                }
            }
            else
            {
                Console.WriteLine("IT Approver email is null or empty.");
            }
        }

        public async Task<MaintenanceRequest?> GetRequestByIdAsync(int RequestId)
        {
            return await _dbContext.MaintenanceRequests
                                  .Include(r => r.User)
                                  .ThenInclude(rs => rs.Plant)
                                  .ThenInclude(p => p.ItApprover)
                                  .ThenInclude(a => a.Backupaprover) // Make sure Backup Approver is included
                                  .Include(sb => sb.IT)
                                  .Include(sb => sb.Controller)
                                  .Include(sb => sb.DeptMnag)
                                  .Include(sb => sb.supplier)
                                  .FirstOrDefaultAsync(s => s.MaintenanceId == RequestId);
        }

        public async Task<IActionResult> UpdateMaintenanceRequestforAdmin(int requestId, MaintenanceRequest updatedRequest)
        {
            // Find the existing phone request in the database
            var existingRequest = await GetRequestByIdAsync(requestId);

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
            if (updatedRequest.PONum!=null)
            {
                updatedRequest.ITconfirmedAt = DateTime.Now;
                updatedRequest.RequestStatus = true;

            }

            // Update only the fields that are not null in the updatedRequest object
            _dbContext.Entry(existingRequest).CurrentValues.SetValues(updatedRequest);

            // Save the changes to the database
            await _dbContext.SaveChangesAsync();

            return new OkObjectResult(new Response { Status = "Success", Message = "Request updated successfully." });
        }

        public async Task<IActionResult> UpdateMaintenanceRequestgenerale( MaintenanceRequest Request)
        {
            // Find the existing phone request in the database

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
            Request.itId = userDetails.Id;
            // Set the actual date
            Request.RequestDate = DateTime.Now;

            // Update only the fields that are not null in the updatedRequest object
            _dbContext.MaintenanceRequests.Add(Request);
            await _dbContext.SaveChangesAsync();

            return new OkObjectResult(new Response { Status = "Success", Message = "Request updated successfully." });
        }

        //KPIs methods
        public int GetRejectedMaintenanceRequestsCount()
        {
            return _dbContext.MaintenanceRequests
                .Count(mr => mr.DepartmangconfirmStatus == false ||
                             mr.ITconfirmSatuts == false ||
                             mr.ControllerconfirmSatuts == false ||
                             mr.PR_Status == false);
        }

        public int GetApprovedMaintenanceRequestsCount()
        {
            return _dbContext.MaintenanceRequests
                .Count(mr => mr.PR_Status == true &&
                             mr.PONum != null &&
                             mr.RequestStatus == true);
        }

        public int GetWaitingForPOMaintenanceRequestsCount()
        {
            return _dbContext.MaintenanceRequests
                .Count(mr => mr.PR_Status == true &&
                             mr.PONum == null);
        }

        public int GetWaitingForPRMaintenanceRequestsCount()
        {
            return _dbContext.MaintenanceRequests
                .Count(mr => mr.DepartmangconfirmStatus == true &&
                             mr.ControllerconfirmSatuts == true &&
                             mr.PR_Status == null);
        }

        public int GetWaitingForFinanceApprovalMaintenanceRequestsCount()
        {
            return _dbContext.MaintenanceRequests
                .Count(mr => mr.DepartmangconfirmStatus == true &&
                             mr.ITconfirmSatuts == null);
        }

        public int GetOpenMaintenanceRequestsCount()
        {
            return _dbContext.MaintenanceRequests
                .Count(mr => !(
                    mr.DepartmangconfirmStatus == false ||
                    mr.ITconfirmSatuts == false ||
                    mr.ControllerconfirmSatuts == false ||
                    mr.PR_Status == false ||
                    (mr.PR_Status == true && mr.PONum == null) ||
                    (mr.DepartmangconfirmStatus == true && mr.ControllerconfirmSatuts == true && mr.PR_Status == null) ||
                    (mr.DepartmangconfirmStatus == true && mr.ITconfirmSatuts == null) ||
                    (mr.PR_Status == true && mr.PONum != null && mr.RequestStatus== true)
                ));
        }
        public async Task<int> GetRequestCount()
        {
            return await _dbContext.MaintenanceRequests.CountAsync();
        }

    }
}

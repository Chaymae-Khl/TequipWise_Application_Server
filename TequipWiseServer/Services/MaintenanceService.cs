using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TequipWiseServer.Data;
using TequipWiseServer.DTO;
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
                var rejectionLink = FixedemailLink + "MaintenanceConfirmation";
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
                                               .Where(r => r.User.Department.ManagerId == managerId ||
                                               r.User.Department.Manager.BackupaproverId == managerId)
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
                                 .Where(r => (r.User.SapNumber.Idcontroller == controllerId ||
                                              r.User.SapNumber.Controller.BackupaproverId == controllerId) &&
                                              r.offer != null)
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

        public async Task<MaintenanceRequest?> UpdateRequestAsync(int equipmentRequestId, MaintenanceRequest updatedRequest)
        {
            // Retrieve the current sub-request details from the database
            var currentSubRequestDetails = await GetRequestByIdAsync(updatedRequest.MaintenanceId);
            if (currentSubRequestDetails == null)
            {
                Console.WriteLine("Request details not found");
                return null;
            }
            var requestUserdetails = await _authService.GetUserByIdAsync(updatedRequest.UserId);
            // Retrieve the authenticated user info
            var userResult = await _authService.GetAuthenticatedUserAsync();
            var okResult = userResult as OkObjectResult;

            if (okResult?.Value is not UserDetailsDTO userDetails)
            {
                Console.WriteLine("Authenticated user not found");
                return null;
            }

            bool statusChanged = false;

            // Check if 'DepartmangconfirmStatus' has been modified
            if (updatedRequest.DepartmangconfirmStatus != currentSubRequestDetails.DepartmangconfirmStatus)
            {
                updatedRequest.deptManagId = userDetails.Id;
                updatedRequest.DepartmangconfirmedAt = DateTime.Now;
                statusChanged = true;

                // Send email to IT Approver or Backup when the manager approves
                await SendEmailAsync(currentSubRequestDetails, "Manager Approval", "maintenanceRequestlist", "RequestApprovalTemplate.html", "Maintenance Request Confirmation Link");
            }

            // Check if the finance status has been changed
            if (updatedRequest.ControllerconfirmSatuts != currentSubRequestDetails.ControllerconfirmSatuts)
            {
                updatedRequest.ControllerId = userDetails.Id;
                updatedRequest.ControllerconfirmedAt = DateTime.Now;
                statusChanged = true;
                await SendEmailAsync(currentSubRequestDetails, "Controller Approval", "maintenanceRequestlist", "RequestApprovalTemplate.html", "Maintenance Request Confirmation Link");
            }

            // Check if PR_Status has been changed
            if (updatedRequest.PR_Status != currentSubRequestDetails.PR_Status)
            {
                updatedRequest.itId = userDetails.Id;
                updatedRequest.ITconfirmedAt = DateTime.Now;

                if (updatedRequest.PR_Status == false)
                {
                    updatedRequest.RequestStatus = false;
                    await SendEmailAsync(currentSubRequestDetails, "Rejection", "maintenanceRequestlist", "EmailRequestConfirmed.html", "Maintenance Request Rejection");
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

                var Useremail = updatedRequest?.User?.Email;
                if (!string.IsNullOrEmpty(Useremail))
                {
                    var rejectionLink = FixedemailLink + "maintenanceRequestlist";
                    var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "EmailRequestConfirmed.html");
                    var emailTemplate = await System.IO.File.ReadAllTextAsync(emailTemplatePath);
                    var emailContent = emailTemplate
                        .Replace("{{resetLink}}", rejectionLink)
                        .Replace("{{TeNum}}", updatedRequest.User.TeNum);
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
                    .Replace("{{UserName}}", updatedRequest.User.TeNum);

                updatedRequest.RequestStatus = false;

                var userEmail = updatedRequest.User?.Email;
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

        private async Task SendEmailAsync(MaintenanceRequest equipmentRequest, string emailType, string linkPath, string templateName, string subject)
        {
            var itApproverEmail = equipmentRequest.User?.Plant?.ItApprover?.Email;
            var itApproverBackup = equipmentRequest.User?.Plant?.ItApprover?.Backupaprover?.Email;

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
                    .Replace("{{TeNum}}", equipmentRequest.User.TeNum);

                if (equipmentRequest.User?.Plant?.ItApprover?.backupActive == true && !string.IsNullOrEmpty(itApproverBackup))
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
    }
}

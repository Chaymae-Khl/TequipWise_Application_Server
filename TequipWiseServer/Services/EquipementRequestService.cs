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
    public class EquipementRequestService : IEquipementRequest
    {

        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthentication _authService;
        private readonly IEMailService _emailService;
        public EquipementRequestService(AppDbContext dbContext, IMapper mapper, UserManager<ApplicationUser> userManager, IAuthentication authService, IEMailService emailService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userManager = userManager;
            _authService = authService;
            _emailService = emailService;
        }
        public string FixedemailLink = "http://localhost:4200/";

        public async Task<IEnumerable<EquipementRequestDTO>> GetRequestsByUserIdAsync(string userId)
        {
            var requests = await _dbContext.EquipmentRequests
        .Where(r => r.UserId == userId)
        .OrderByDescending(r => r.RequestDate)
        .Include(r => r.User)
        .Include(r => r.EquipmentSubRequests)
            .ThenInclude(sr => sr.DeparManag)
        .Include(r => r.EquipmentSubRequests)
            .ThenInclude(sr => sr.IT)
        .Include(r => r.EquipmentSubRequests)
            .ThenInclude(sr => sr.Controller)
        .Include(r => r.EquipmentSubRequests)
            .ThenInclude(sr => sr.Equipment)
        .ToListAsync();

            return _mapper.Map<IEnumerable<EquipementRequestDTO>>(requests);
        }
        async public Task<IActionResult> PassRequest(EquipmentRequest request)
        {
            _dbContext.EquipmentRequests.Add(request);
            await _dbContext.SaveChangesAsync();
            return new OkObjectResult(new Response { Status = "Success", Message = "Request passed successfully!" });

        }


        public async Task<int> GetRequestCountByUserIdAsync(string userId)
        {
            return await _dbContext.EquipmentRequests
                .CountAsync(r => r.UserId == userId);
        }

        // Get the requests of the department manager
        public async Task<IEnumerable<EquipementRequestDTO>> GetRequestsForDepartmentManagerAsync(string managerId)
        {
            var requests = await _dbContext.EquipmentRequests
                                           .Where(r => r.User.Department.ManagerId == managerId)
                                           .OrderByDescending(r => r.RequestDate)
                                           .Include(r => r.User)
                                           .ThenInclude(rs => rs.SapNumber)
                                           .Include(r => r.EquipmentSubRequests)
                                           .ThenInclude(sb => sb.IT)
                                           .Include(r => r.EquipmentSubRequests)
                                           .ThenInclude(sb => sb.Controller)
                                           .Include(r => r.EquipmentSubRequests)
                                           .ThenInclude(sb => sb.DeparManag)
                                            .Include(r => r.EquipmentSubRequests)
                                            .ThenInclude(sr => sr.Equipment)
                                           .AsNoTracking()
                                           .ToListAsync();

            return _mapper.Map<IEnumerable<EquipementRequestDTO>>(requests);
        }
        public async Task<IEnumerable<EquipementRequestDTO>> GetRequestsForLocationITApproverAsync(string Itapproverid)
        {
            // Step 1: Find the plant IDs where the user is the IT approver
            var plantIds = await _dbContext.Plants
                                           .Where(p => p.ITApproverId == Itapproverid)
                                           .Select(p => p.PlantNumber)
                                           .ToListAsync();

            // Debug: Log or inspect plant IDs
            Console.WriteLine("Plant IDs where the user is IT approver:");
            foreach (var id in plantIds)
            {
                Console.WriteLine($"Plant ID: {id}");
            }

            // Check if plantIds is empty
            if (!plantIds.Any())
            {
                Console.WriteLine("No plant IDs found for the given IT approver.");
                return Enumerable.Empty<EquipementRequestDTO>();
            }

            // Step 2: Get the requests for those plants where at least one subrequest has deptmangestatus as true
            var requests = await _dbContext.EquipmentRequests
                                           .Where(r => r.User.plantId.HasValue && plantIds.Contains(r.User.plantId.Value) &&
                                                       r.EquipmentSubRequests.Any(sub => sub.DepartmangconfirmStatus == true))
                                           .OrderByDescending(r => r.RequestDate)
                                           .Include(r => r.User)
                                            .ThenInclude(rs => rs.SapNumber)
                                           .Include(r => r.EquipmentSubRequests)
                                           .ThenInclude(sb => sb.IT)
                                           .Include(r => r.EquipmentSubRequests)
                                           .ThenInclude(sb => sb.Controller)
                                           .Include(r => r.EquipmentSubRequests)
                                           .ThenInclude(sb => sb.DeparManag)
                                           .Include(r => r.EquipmentSubRequests)
                                           .ThenInclude(sr => sr.Equipment)
                                           .AsNoTracking()
                                           .ToListAsync();

            // Debug: Log or inspect requests count
            Console.WriteLine($"Total requests found: {requests.Count}");
            foreach (var request in requests)
            {
                Console.WriteLine($"Request ID: {request.EquipmentRequestId}, Plant ID: {request.User.plantId}");
            }

            return _mapper.Map<IEnumerable<EquipementRequestDTO>>(requests);
        }

        public async Task<IEnumerable<EquipementRequestDTO>> GetRequestsForSapControllerAsync(string controllerId)
        {
            var requests = await _dbContext.EquipmentRequests
                                           .Where(r => r.User.SapNumber.Idcontroller == controllerId && r.SupplierOffer != null)
                                           .OrderByDescending(r => r.RequestDate)
                                           .Include(r => r.User)
                                           .ThenInclude(u => u.SapNumber)
                                           .Include(r => r.EquipmentSubRequests)
                                           .ThenInclude(sr => sr.IT)
                                           .Include(r => r.EquipmentSubRequests)
                                           .ThenInclude(sr => sr.Controller)
                                           .Include(r => r.EquipmentSubRequests)
                                           .ThenInclude(sr => sr.DeparManag)
                                           .Include(r => r.EquipmentSubRequests)
                                           .ThenInclude(sr => sr.Equipment)
                                           .AsNoTracking()
                                           .ToListAsync();

            return _mapper.Map<IEnumerable<EquipementRequestDTO>>(requests);
        }
        public async Task<IEnumerable<EquipementRequestDTO>> GetRequestsForAdminAsync(string controllerId)
        {
            var requests = await _dbContext.EquipmentRequests
                                           .OrderByDescending(r => r.RequestDate)
                                           .Include(r => r.User)
                                           .ThenInclude(u => u.SapNumber)
                                           .Include(r => r.EquipmentSubRequests)
                                           .ThenInclude(sr => sr.IT)
                                           .Include(r => r.EquipmentSubRequests)
                                           .ThenInclude(sr => sr.Controller)
                                           .Include(r => r.EquipmentSubRequests)
                                           .ThenInclude(sr => sr.DeparManag)
                                           .Include(r => r.EquipmentSubRequests)
                                           .ThenInclude(sr => sr.Equipment)
                                           .AsNoTracking()
                                           .ToListAsync();

            return _mapper.Map<IEnumerable<EquipementRequestDTO>>(requests);
        }
        //using the class
        public async Task<EquipmentRequest?> GetRequestByIdAsyncOrig(int equipmentRequestId)
        {
            return await _dbContext.EquipmentRequests
                .Include(u=>u.User)
                .Include(s=>s.EquipmentSubRequests)
                 .AsNoTracking()
                .FirstOrDefaultAsync(r=>r.EquipmentRequestId==equipmentRequestId);
        }

        //using dto
        public async Task<EquipementRequestDTO> GetRequestByIdAsync(int requestId)
        {
            var request = await _dbContext.EquipmentRequests
                .Include(r => r.User)
                  .ThenInclude(rp => rp.Plant)
                  .ThenInclude(pi => pi.ItApprover)
                  .Include(r => r.EquipmentSubRequests)
                   .ThenInclude(sb => sb.IT)
                  .Include(r => r.EquipmentSubRequests)
                   .ThenInclude(sb => sb.Controller)
                  .Include(r => r.EquipmentSubRequests)
                   .ThenInclude(sb => sb.DeparManag)
                  .Include(r => r.EquipmentSubRequests)
                   .ThenInclude(sr => sr.Equipment)
                 .AsNoTracking()
           .FirstOrDefaultAsync(r => r.EquipmentRequestId == requestId);
            if (request == null)
            {
                return null;
            }
            Console.WriteLine($"================User: {request}");

            var requestsDetails = _mapper.Map<EquipementRequestDTO>(request);
            return requestsDetails;
        }

        //when the manager approves
        public async Task<SubEquipmentRequest?> UpdateSubRequestAsync(int equipmentRequestId, SubEquipmentRequest updatedSubRequest)
        {
            // Retrieve main request of the subrequest
            var equipmentRequest = await _dbContext.EquipmentRequests
                .Include(er => er.EquipmentSubRequests)
                .Include(u => u.User)
                .ThenInclude(up => up.Plant)
                .ThenInclude(pi => pi.ItApprover)
                .ThenInclude(bb => bb.Backupaprover)
                .FirstOrDefaultAsync(er => er.EquipmentRequestId == equipmentRequestId);

            if (equipmentRequest == null)
            {
                Console.WriteLine("Main request not found");
                return null; // Main request not found
            }

            // Retrieve the current sub-request details from the database
            var currentSubRequestDetails = await GetSubRequestByIdAsync(updatedSubRequest.SubEquipmentRequestId);
            if (currentSubRequestDetails == null)
            {
                Console.WriteLine("Sub-request details not found");
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

            bool statusChanged = false;

            // Check if 'DepartmangconfirmStatus' has been modified
            if (updatedSubRequest.DepartmangconfirmStatus != currentSubRequestDetails.DepartmangconfirmStatus)
            {
                updatedSubRequest.deptManagId = userDetails.Id;
                updatedSubRequest.DepartmangconfirmedAt = DateTime.Now;
                statusChanged = true;

                // Send email to IT Approver or Backup when the manager approves
                await SendEmailAsync(equipmentRequest, "Manager Approval", "RequestConfirmation", "RequestApprovalTemplate.html", "Equipment Request Confirmation Link");
            }

            // Check if the finance status has been changed
            if (updatedSubRequest.FinanceconfirmSatuts != currentSubRequestDetails.FinanceconfirmSatuts)
            {
                updatedSubRequest.controllerid = userDetails.Id;
                updatedSubRequest.FinanceconfirmedAt = DateTime.Now;
                statusChanged = true;
                await SendEmailAsync(equipmentRequest, "Controller Approval", "RequestConfirmation", "RequestApprovalTemplate.html", "Equipment Request Confirmation Link");

            }

            // Check if PR_Status has been changed
            if (updatedSubRequest.PR_Status != currentSubRequestDetails.PR_Status)
            {
                updatedSubRequest.itId = userDetails.Id;
                updatedSubRequest.ITconfirmedAt = DateTime.Now;

                if (updatedSubRequest.PR_Status == false)
                {
                    updatedSubRequest.SubRequestStatus = false;
                    equipmentRequest.RequestStatus = false;
                    await SendEmailAsync(equipmentRequest, "Rejection", "UserEquipementRequest", "EmailRequestConfirmed.html", "Equipment Request Rejection");
                    Console.WriteLine("=================== the sub-request is rejected ");
                }
                statusChanged = true;
            }

            // Check if PONum has been changed
            if (updatedSubRequest.PONum != currentSubRequestDetails.PONum)
            {
                updatedSubRequest.itId = userDetails.Id;
                updatedSubRequest.ITconfirmSatuts = true;
                updatedSubRequest.ITconfirmedAt = DateTime.Now;
                updatedSubRequest.SubRequestStatus = true;
                equipmentRequest.RequestStatus = true;
                await SendEmailAsync(equipmentRequest, "Confirmation", "UserEquipementRequest", "EmailRequestConfirmed.html", "Equipment Request Confirmation");
                Console.WriteLine("=================== the sub-request is approved ");
                statusChanged = true;
            }

            // Change the global status of the request to false if rejected
            if (updatedSubRequest.DepartmangconfirmStatus == false || updatedSubRequest.ITconfirmSatuts == false || updatedSubRequest.FinanceconfirmSatuts == false)
            {
                var rejectionLink = FixedemailLink + "UserEquipementRequest";
                var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "RejectionTemplate.html");
                var emailTemplate = await System.IO.File.ReadAllTextAsync(emailTemplatePath);
                var emailContent = emailTemplate
                    .Replace("{{resetLink}}", rejectionLink)
                    .Replace("{{equipment}}", currentSubRequestDetails.Equipment.EquipName)
                    .Replace("{{UserName}}", equipmentRequest.User.TeNum);

                updatedSubRequest.SubRequestStatus = false;

                var userEmail = equipmentRequest.User?.Email;
                if (!string.IsNullOrEmpty(userEmail))
                {
                    var message = new Message(new[] { userEmail }, "Equipment Request Rejection", emailContent, isHtml: true);
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
            var properties = typeof(SubEquipmentRequest).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var newValue = property.GetValue(updatedSubRequest);
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

        private async Task SendEmailAsync(EquipmentRequest equipmentRequest, string emailType, string linkPath, string templateName, string subject)
        {
            var itApproverEmail = equipmentRequest.User.Plant?.ItApprover?.Email;
            var itApproverBackup = equipmentRequest.User.Plant?.ItApprover?.Backupaprover?.Email;
            Console.WriteLine("IT Approver Email: " + itApproverEmail);
            Console.WriteLine("IT Approver backup Email: " + itApproverBackup);

            if (!string.IsNullOrEmpty(itApproverEmail))
            {
                var itApproverLink = FixedemailLink + linkPath;
                var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", templateName);
                var emailTemplate = await System.IO.File.ReadAllTextAsync(emailTemplatePath);
                var emailContent = emailTemplate
                    .Replace("{{resetLink}}", itApproverLink)
                    .Replace("{{TeNum}}", equipmentRequest.User.TeNum);

                if (equipmentRequest.User.Plant?.ItApprover?.backupActive == true && !string.IsNullOrEmpty(itApproverBackup))
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



        public async Task<EquipmentRequest?> RequestSupplierOfferAndPU(int equipmentRequestId, EquipmentRequest updatedRequest)
        {
            // Retrieve current request of the subrequest
            var equipmentRequest = await _dbContext.EquipmentRequests
                .Include(er => er.EquipmentSubRequests)
                .Include(u => u.User)
                .ThenInclude(uc => uc.SapNumber)
                .ThenInclude(us => us.Controller)
                .ThenInclude(us => us.Backupaprover)
                .FirstOrDefaultAsync(er => er.EquipmentRequestId == equipmentRequestId);

            if (equipmentRequest == null)
            {
                Console.WriteLine("Request not found");
                return null; // Main request not found
            }

            // Detach tracked sub-requests to avoid conflict
            foreach (var subRequest in equipmentRequest.EquipmentSubRequests)
            {
                _dbContext.Entry(subRequest).State = EntityState.Detached;
            }

            // Retrieve the authenticated user info
            var userResult = await _authService.GetAuthenticatedUserAsync();
            var okResult = userResult as OkObjectResult;

            if (okResult?.Value is not UserDetailsDTO userDetails)
            {
                Console.WriteLine("Authenticated user not found");
                return null;
            }

            // Get the controller email and backup approver email with null checks
            var controller = equipmentRequest.User.SapNumber?.Controller;
            var controllerEmail = controller?.Email;
            var controllerBackupEmail = controller?.Backupaprover?.Email;

            Console.WriteLine("Controller Email: " + controllerEmail);
            Console.WriteLine("Controller backup Email: " + controllerBackupEmail);

            if (!string.IsNullOrEmpty(controllerEmail))
            {
                var itApproverLink = FixedemailLink + "RequestConfirmation";
                var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "RequestApprovalTemplate.html");
                var emailTemplate = await System.IO.File.ReadAllTextAsync(emailTemplatePath);
                var emailContent = emailTemplate
                    .Replace("{{resetLink}}", itApproverLink)
                    .Replace("{{TeNum}}", equipmentRequest.User.TeNum);

                if (controller?.backupActive == true && !string.IsNullOrEmpty(controllerBackupEmail))
                {
                    var message = new Message(new[] { controllerBackupEmail }, "Equipment Request Confirmation Link", emailContent, isHtml: true);
                    _emailService.SendEmail(message);
                }
                else
                {
                    var message2 = new Message(new[] { controllerEmail }, "Equipment Request Confirmation Link", emailContent, isHtml: true);
                    _emailService.SendEmail(message2);
                }
            }
            else
            {
                Console.WriteLine("IT Approver email is null or empty.");
            }

            // Update only the properties that are not null in updatedRequest, excluding key properties
            var properties = typeof(EquipmentRequest).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                if (property.Name == nameof(EquipmentRequest.EquipmentRequestId))
                {
                    continue; // Skip updating key property
                }

                var newValue = property.GetValue(updatedRequest);
                if (newValue != null)
                {
                    property.SetValue(equipmentRequest, newValue);
                }
            }

            // Reattach updated sub-requests
            foreach (var subRequest in updatedRequest.EquipmentSubRequests)
            {
                _dbContext.Entry(subRequest).State = EntityState.Modified;
            }

            await _dbContext.SaveChangesAsync();

            return equipmentRequest;
        }



       

        async public Task<SubEquipmentRequest> GetSubRequestByIdAsync(int subRequestId)
        {
            return await _dbContext.subEquipmentRequests
                               .Include(s => s.EquipRequest)
                               .Include(s => s.DeparManag)
                               .Include(s => s.IT)
                               .Include(s => s.Controller)
                               .Include(e => e.Equipment)
                               .Include(e => e.EquipRequest)
                               .ThenInclude(eu => eu.User)
                               .FirstOrDefaultAsync(s => s.SubEquipmentRequestId == subRequestId);
        }
    }
    }


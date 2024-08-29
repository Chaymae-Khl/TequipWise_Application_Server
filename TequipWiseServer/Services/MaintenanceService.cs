using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    }
}

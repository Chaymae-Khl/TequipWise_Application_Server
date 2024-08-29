using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TequipWiseServer.DTO;
using TequipWiseServer.Helpers;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;
using TequipWiseServer.Services;

namespace TequipWiseServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MaintenanceController : ControllerBase
    {
        private readonly IMaintenance _MaintenacerequestService;
        private readonly IAuthentication _authService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Isupplier _supplierService;
        public MaintenanceController(IMaintenance maintenacerequestService, IAuthentication authService, UserManager<ApplicationUser> userManager, Isupplier supplierService)
        {
            _MaintenacerequestService = maintenacerequestService;
            _authService = authService;
            _userManager = userManager;
            _supplierService = supplierService;
        }

        [HttpPost("PassMaintenanceRequest")]
        public async Task<IActionResult> PassRequest([FromForm] MaintenanceRequest newrequest, IFormFile? file)
        {
            if (file != null)
            {
                var fileUploadHelper = new FileUploadHelper();
                string filePath;
                try
                {
                    filePath = await fileUploadHelper.UploadFileAsync(file);
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(new Response { Status = "Error", Message = ex.Message });
                }
                newrequest.offer = filePath;
            }
            // Save the request in the database
            await _MaintenacerequestService.PassMaintenanceRequest(newrequest);


            return StatusCode(StatusCodes.Status200OK,
                new Response { Status = "Success", Message = "Request processed and notification sent." });

        }
        [HttpGet("DepartmentRequests")]
        public async Task<IActionResult> GetDepartmentRequests()
        {
            var userResult = await _authService.GetAuthenticatedUserAsync();

            if (userResult is UnauthorizedResult)
            {
                return Unauthorized();
            }

            var okResult = userResult as OkObjectResult;
            if (okResult == null || okResult.Value == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Failed to retrieve authenticated user details." });
            }

            var userDetails = okResult.Value as UserDetailsDTO;
            if (userDetails == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "User details are missing." });
            }

            var roles = await _userManager.GetRolesAsync(new ApplicationUser { Id = userDetails.Id });

            IEnumerable<MaintenanceRequestDTO> requests;

            if (roles.Contains("Manager") || roles.Contains("ManagerBackupApprover"))
            {
                requests = await _MaintenacerequestService.GetRequestsForDepartmentManagerAsync(userDetails.Id);
            }
            else if (roles.Contains("It Approver") || roles.Contains("ItBackupApprover"))
            {
                requests = await _MaintenacerequestService.GetRequestsForITAsync(userDetails.Id);
            }
            else if (roles.Contains("Controller") || roles.Contains("ControllerBackupApprover"))
            {
                requests = await _MaintenacerequestService.GetRequestsForSapControllerAsync(userDetails.Id);
            }
            else if (roles.Contains("Admin"))
            {
                requests = await _MaintenacerequestService.GetRequestsForAdminAsync(userDetails.Id);
            }
            else if (roles.Contains("Approver"))
            {
                requests = await _MaintenacerequestService.GetRequestsForApproverAsync(userDetails.Id);
            }
            else
            {
                return Forbid();
            }

            return Ok(requests);
        }

        [HttpGet("Users")]
        public async Task<ActionResult<List<UserDetailsDTO>>> GetAllUsers()
        {
            var users = await _authService.GetUsers();
            return Ok(users);
        }

        [HttpGet("Suppliers")]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetAllSuppliers()
        {
            var suppliers = await _supplierService.GetSuppliers();
            return Ok(suppliers);
        }
    }
}

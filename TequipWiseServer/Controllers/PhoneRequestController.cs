using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TequipWiseServer.DTO;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;
using TequipWiseServer.Services;
using User.Managmenet.Service.Models;

namespace TequipWiseServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class PhoneRequestController : ControllerBase
    {
        private readonly IPhoneRequest _PhonerequestService;
        private readonly IAuthentication _authService;
        private readonly UserManager<ApplicationUser> _userManager;
        public PhoneRequestController(IPhoneRequest requestService, IAuthentication authService, UserManager<ApplicationUser> userManager)
        {
            _PhonerequestService = requestService;
            _authService = authService;
            _userManager = userManager;
        }

        [HttpPost("PassPhoneRequest")]
        public async Task<IActionResult> PassRequest([FromBody] PhoneRequest newrequest)
        {

            // Call the service method and get the result
            var result = await _PhonerequestService.PassPhoneRequest(newrequest);

            // Return the exact result returned by the service
            return result;

        }
        ////get the phone requests of the authenticated user

        [HttpGet("GetUserPhoneRequests")]
        public async Task<IActionResult> GetUserRequests()
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
                return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Status = "Error", Message = "User details are missing." });
            }

            var userRequests = await _PhonerequestService.GetRequestsByUserIdAsync(userDetails.Id);

            return Ok(userRequests);
        }

        [HttpGet("ApproversRequests")]
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

            IEnumerable<PhoneRequestDTO> requests;

            if (roles.Contains("Manager") || roles.Contains("ManagerBackupApprover"))
            {
                requests = await _PhonerequestService.GetRequestsForDepartmentManagerAsync(userDetails.Id);
            }
            else if (roles.Contains("It Approver") || roles.Contains("ItBackupApprover"))
            {
                requests = await _PhonerequestService.GetRequestsForPlantITApproverAsync(userDetails.Id);
            }
            else if (roles.Contains("HR Approver") || roles.Contains("HRBackupApprover"))
            {
                requests = await _PhonerequestService.GetRequestsForPlantHRApproverAsync(userDetails.Id);
            }
            else if (roles.Contains("Admin"))
            {
                requests = await _PhonerequestService.GetRequestsForAdminAsync(userDetails.Id);
            }
            else if (roles.Contains("Approver"))
            {
                requests = await _PhonerequestService.GetRequestsForApproverAsync(userDetails.Id);
            }
            else
            {
                return Forbid();
            }

            return Ok(requests);
        }

        [HttpPatch("UpdatePhoneRequest/{id}")]
        public async Task<IActionResult> UpdateRequest(int id, [FromBody] PhoneRequest updatedRequest)
        {
            if (updatedRequest == null)
            {
                return BadRequest(new Response { Status = "Error", Message = "Invalid request data." });
            }

            var result = await _PhonerequestService.UpdatePhoneRequest(id, updatedRequest);

            return result;
        }

        [HttpPatch("UpdatePhoneRequestAdmin/{id}")]
        public async Task<IActionResult> UpdateRequestAdmin(int id, [FromBody] PhoneRequest updatedRequest)
        {
            if (updatedRequest == null)
            {
                return BadRequest(new Response { Status = "Error", Message = "Invalid request data." });
            }

            var result = await _PhonerequestService.UpdatePhoneRequestforAdmin(id, updatedRequest);

            return result;
        }
        [HttpGet("user-phones")]
        public async Task<IActionResult> GetUserPhones()
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
                return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Status = "Error", Message = "User details are missing." });
            }

            var userRequests = await _PhonerequestService.GetAssignedPhonesForUserAsync(userDetails.Id);

            return Ok(userRequests);
        }
        [HttpGet("GetPhoneRequestCount")]
        public async Task<ActionResult<int>> GetNumberofUsers()
        {
            var numReq = await _PhonerequestService.GetRequestPhneCountIdAsync();
            return Ok(numReq);
        }
        [HttpGet("counts")]
        public IActionResult GetRequestCounts()
        {
            var counts = new
            {
                Open = _PhonerequestService.GetOpenRequestsCount(),
                InProgress = _PhonerequestService.GetInProgressRequestsCount(),
                WaitingForIT = _PhonerequestService.GetWaitingForITRequestsCount(),
                WaitingForHR = _PhonerequestService.GetWaitingForHRRequestsCount(),
                Approved = _PhonerequestService.GetApprovedRequestsCount(),
                Rejected = _PhonerequestService.GetRejectedRequestsCount(),
            };

            return Ok(counts);
        }
    }
}

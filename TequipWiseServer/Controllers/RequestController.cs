using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TequipWiseServer.DTO;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;
using TequipWiseServer.Services;
using User.Managmenet.Service.Models;
using User.Managmenet.Service.Services;

namespace TequipWiseServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RequestController : ControllerBase
    {
        private readonly IEquipementRequest _requestService;
        private readonly IAuthentication _authService;
        private readonly IEMailService _emailService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEquipment _equipmentService;
        public RequestController(IEquipementRequest requestService, IAuthentication authService, IEMailService emailService, UserManager<ApplicationUser> userManager, IEquipment equipmentService)
        {
            _requestService = requestService;
            _authService = authService;
            _emailService = emailService;
            _userManager = userManager;
            _equipmentService = equipmentService;
        }

        public string FixedemailLink = "http://localhost:4200/";

        [HttpPost("PassEquipemntRequest")]
        public async Task<IActionResult> PassRequest([FromBody] UserEquipmentRequest newrequest)
        {
            // Get the authenticated user details
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
            if (userDetails == null || userDetails.Department == null || userDetails.Department.Manager == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Status = "Error", Message = "User's department or department manager information is missing." });
            }

            newrequest.UserId = userDetails.Id;

            // Save the request in the database
            var result = await _requestService.PassRequest(newrequest);
            if (result is OkObjectResult == false)
            {
                return result;
            }

            var haveApprover = userDetails.ApproverActive;

            if (haveApprover==true)
            {
                var ApproverEmail = userDetails.ApproverEmail;
                if (string.IsNullOrEmpty(ApproverEmail))
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                        new Response { Status = "Error", Message = "Approver email is missing." });
                }

                var approver = await _userManager.FindByEmailAsync(ApproverEmail);
                if (approver != null)
                {
                    // Generate a token for confirming the request (not for password reset)
                    var token = await _userManager.GenerateUserTokenAsync(approver, TokenOptions.DefaultProvider, "EquipmentRequest");
                    var deptmangLink = FixedemailLink + "RequestConfirmation";

                    var message = new Message(new string[] { approver.Email }, "Equipment Request Confirmation Link", "Hi, you have new request follow this link =>>" + deptmangLink);
                    _emailService.SendEmail(message);

                    return StatusCode(StatusCodes.Status200OK,
                        new Response { Status = "Success", Message = $"Equipment request confirmation link sent to your approver by email." });
                }
            }
            else
            {
             var deptmanagerEmail = userDetails.ManagerEmail;
            if (string.IsNullOrEmpty(deptmanagerEmail))
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Status = "Error", Message = "Department manager's email is missing." });
            }

            var manager = await _userManager.FindByEmailAsync(deptmanagerEmail);
            if (manager != null)
            {
                // Generate a token for confirming the request (not for password reset)
                var token = await _userManager.GenerateUserTokenAsync(manager, TokenOptions.DefaultProvider, "EquipmentRequest");
                var deptmangLink = FixedemailLink+ "RequestConfirmation";

                var message = new Message(new string[] { manager.Email }, "Equipment Request Confirmation Link","Hi, you have new request follow this link =>>"+ deptmangLink);
                _emailService.SendEmail(message);

                return StatusCode(StatusCodes.Status200OK,
                    new Response { Status = "Success", Message = $"Equipment request confirmation link sent to the manager of you department by email." });
            }
            }

           

            return result;
        }

        //get the requests of the authenticated user

        [HttpGet("GetUserRequests")]
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

            var userRequests = await _requestService.GetRequestsByUserIdAsync(userDetails.Id);

            return Ok(userRequests);
        }

        [HttpGet("GetUserRequestCount")]
        public async Task<IActionResult> GetUserRequestCount()
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

            var requestCount = await _requestService.GetRequestCountByUserIdAsync(userDetails.Id);

            return Ok(new { Count = requestCount });
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
            if (!roles.Contains("DeptManager"))
            {
                return Forbid();
            }

            var requests = await _requestService.GetRequestsForDepartmentManagerAsync(userDetails.Id);

            return Ok(requests);
        }






        [HttpGet("EquipemntName")]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetAllEquipemntName()
        {
            var Equipmentname = await _equipmentService.GetEquipemntInfoAsync();
            return Ok(Equipmentname);
        }
    }


}

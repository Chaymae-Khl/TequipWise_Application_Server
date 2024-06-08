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

        public RequestController(IEquipementRequest requestService, IAuthentication authService, IEMailService emailService, UserManager<ApplicationUser> userManager)
        {
            _requestService = requestService;
            _authService = authService;
            _emailService = emailService;
            _userManager = userManager;
        }


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

            var result = await _requestService.PassRequest(newrequest);

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
                var deptmangLink = $"http://localhost:4200/Request?token={Uri.EscapeDataString(token)}&email={Uri.EscapeDataString(manager.Email)}";

                var message = new Message(new string[] { manager.Email }, "Equipment Request Confirmation Link", deptmangLink);
                _emailService.SendEmail(message);

                return StatusCode(StatusCodes.Status200OK,
                    new Response { Status = "Success", Message = $"Equipment request confirmation link sent to email {manager.Email} successfully." });
            }

            return result;
        }


    }
}

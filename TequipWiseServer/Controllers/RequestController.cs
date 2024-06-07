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

            var user = await _authService.GetAuthenticatedUserAsync();
            if (user == null)
            {
                return Unauthorized();
            }

            if (user.Department == null || user.Department.Manager == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Status = "Error", Message = "User's department or department manager information is missing." });
            }

            newrequest.UserId = user.Id;

            var result = await _requestService.PassRequest(newrequest);

            var deptmanagerEmail = user.Department.Manager.Email;
            if (string.IsNullOrEmpty(deptmanagerEmail))
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Status = "Error", Message = "Department manager's email is missing." });
            }

            var manager = await _userManager.FindByEmailAsync(deptmanagerEmail);
            if (manager != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var deptmangLink = $"http://localhost:4200/Request?token={Uri.EscapeDataString(token)}&email={Uri.EscapeDataString(manager.Email)}";

                var message = new Message(new string[] { manager.Email }, "Equipment Request Confirmation link", deptmangLink);
                _emailService.SendEmail(message);

                return StatusCode(StatusCodes.Status200OK,
                    new Response { Status = "Success", Message = $"Password change request is sent to email {user.Email} successfully." });
            }

            return result;
        }



    }
}

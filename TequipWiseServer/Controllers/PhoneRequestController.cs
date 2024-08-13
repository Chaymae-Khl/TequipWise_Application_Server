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
    public class PhoneRequestController : ControllerBase
    {
        private readonly IPhoneRequest _PhonerequestService;
        private readonly IAuthentication _authService;
        public PhoneRequestController(IPhoneRequest requestService, IAuthentication authService)
        {
            _PhonerequestService = requestService;
            _authService = authService;

        }

        [HttpPost("PassPhoneRequest")]
        public async Task<IActionResult> PassRequest([FromBody] PhoneRequest newrequest)
        {
           
          
            // Save the request in the database
             await _PhonerequestService.PassPhoneRequest(newrequest);
         

            return StatusCode(StatusCodes.Status200OK,
                new Response { Status = "Success", Message = "Request processed and notification sent." });

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

    }
}

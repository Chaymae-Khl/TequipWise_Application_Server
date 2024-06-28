using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TequipWiseServer.DTO;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;

namespace TequipWiseServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UserController : ControllerBase
    {

        private readonly IAuthentication _authService;


        public UserController(IAuthentication authService)
        {
            _authService = authService;
        }

        [HttpGet("GetAuthenticatedUser")]
        public async Task<IActionResult> GetAuthenticatedUserDetails()
        {
            return await _authService.GetAuthenticatedUserAsync();
        }
        [HttpPut("updateProfile/{userId}")]
        public async Task<IActionResult> UpdateUser(string userId, [FromBody] UserDetailsDTO updatedUserDetails)
        {
            // Update the user details
            var result = await _authService.UpdateUser(userId, updatedUserDetails);
            return result;
        }

        [HttpPost("updatePasswordProfile/{userId}")]
        public async Task<IActionResult> ChangeUserPassword(string userId, [FromBody] string newPassword)
        {
            var result = await _authService.ChangeUserPassword(userId, newPassword);
            return result;
        }

        [HttpGet("Users")]
        public async Task<ActionResult<List<UserDetailsDTO>>> GetAllUsers()
        {
            var users = await _authService.GetUsers();
            return Ok(users);
        }



    }
}

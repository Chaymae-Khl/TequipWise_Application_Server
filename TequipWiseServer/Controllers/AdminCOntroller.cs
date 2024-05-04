using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TequipWiseServer.DTO;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;

namespace TequipWiseServer.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class AdminCOntroller : ControllerBase
    {

        private readonly IAuthentication _authService;

        public AdminCOntroller(IAuthentication authService)
        {
            _authService = authService;
        }

        [HttpGet("Users")]
        public async Task<ActionResult<List<UserDetailsDTO>>> GetAllUsers()
        {
            var users = await _authService.GetUsers();
            return Ok(users);
        }

        [HttpDelete("DeleteUser/{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            return await _authService.DeleteUser(userId);
        }

        [HttpPut("update/{userId}")]
        public async Task<IActionResult> UpdateUser(string userId, [FromBody] UserDetailsDTO updatedUserDetails)
        {
          
            var result = await _authService.UpdateUser(userId, updatedUserDetails);
            return result;
        }

        [HttpGet("allRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            return await _authService.GetAllRoles();
        }
    }
}

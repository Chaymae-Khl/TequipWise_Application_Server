using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TequipWiseServer.Models.Authentication.SignIn;
using TequipWiseServer.Models.Authentication.SignUp;
using TequipWiseServer.DTO;
using TequipWiseServer.Models;

namespace TequipWiseServer.Interfaces
{
    public interface IAuthentication
    {
        Task<int> GetUserCount();
        Task<IActionResult> Register([FromBody] RegisterUser registerUser, string role);
        Task<IActionResult> Login([FromBody] LoginModal loginmodal);
        Task<List<UserDetailsDTO>> GetUsers();
        Task<IActionResult> DeleteUser(string userId);
        Task<IActionResult> UpdateUser(string userId, UserDetailsDTO updatedUserDetails);
        Task<IActionResult> GetAllRoles();
        Task<IActionResult> ChangeUserPassword(string userId, string newPassword);
        Task<ApplicationUser> GetAuthenticatedUserAsync();
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyAvocatApi.Models.Authentication.SignIn;
using MyAvocatApi.Models.Authentication.SignUp;

namespace TequipWiseServer.Interfaces
{
    public interface IAuthentication
    {
        Task<IActionResult> Register([FromBody] RegisterUser registerUser, string role);
        Task<IActionResult> Login([FromBody] LoginModal loginmodal);
    }
}

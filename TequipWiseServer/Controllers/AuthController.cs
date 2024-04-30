using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAvocatApi.Models.Authentication.SignIn;
using MyAvocatApi.Models.Authentication.SignUp;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Services;

namespace TequipWiseServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
      private readonly IAuthentication _authService;
        public AuthController(IAuthentication authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser, string role)
        {
            return await _authService.Register(registerUser, role);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModal loginmodal)
        {
            return await _authService.Login(loginmodal);
        }

       


    }
}

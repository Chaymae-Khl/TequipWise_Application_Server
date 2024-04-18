using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAvocatApi.Models.Authentication.SignIn;
using MyAvocatApi.Models.Authentication.SignUp;
using TequipWiseServer.Services;

namespace TequipWiseServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
      private readonly AuthService _authService;

        public AuthController(AuthService authService)
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

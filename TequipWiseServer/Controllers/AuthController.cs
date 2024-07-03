using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TequipWiseServer.Models;
using TequipWiseServer.Models.Authentication.SignIn;
using TequipWiseServer.Models.Authentication.SignUp;
using System;
using System.ComponentModel.DataAnnotations;
using TequipWiseServer.DTO;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;
using TequipWiseServer.Models.Authentication;
using TequipWiseServer.Services;
using User.Managmenet.Service.Models;
using User.Managmenet.Service.Services;
using Newtonsoft.Json;
using System.Diagnostics;

namespace TequipWiseServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthentication _authService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEMailService _emailService;


        public AuthController(IAuthentication authService, UserManager<ApplicationUser> userManager, IEMailService emailService)
        {
            _authService = authService;
            _userManager = userManager;
            _emailService = emailService;
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

        [HttpPost("tokenEmail")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([Required] string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { errors = new { Email = new[] { "The email field is required." } } });
            }

            var user = await _userManager.FindByEmailAsync(Email);
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user!);
                var forgotPasswordLink = $"http://localhost:4200/forgetPassword?token={Uri.EscapeDataString(token)}&email={Uri.EscapeDataString(user.Email)}";

                var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "EmailTemplate.html");
                var emailTemplate = await System.IO.File.ReadAllTextAsync(emailTemplatePath);
                var emailContent = emailTemplate.Replace("{{resetLink}}", forgotPasswordLink);

                var message = new Message(new string[] { user.Email! }, "Forgot Password link", emailContent, isHtml: true);
                _emailService.SendEmail(message);
                return StatusCode(StatusCodes.Status200OK,
                    new Response { Status = "Success", Message = $"Password change request is sent to email {user.Email} successfully." });
            }

            return StatusCode(StatusCodes.Status400BadRequest,
                new Response { Status = "Error", Message = "Could not send link to email. Please try again." });
        }

        [HttpGet("reset-password")]
        public async Task<IActionResult> ResetPassword(string token, string email)
        {
            var model = new ForgotPasswordModel { Token = token, Email = email };
            return Ok(new { model });
        }


        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ForgotPasswordModel forgotPasswordModel)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordModel.Email);
            if (user != null)
            {
                var resetPassResult = await _userManager.ResetPasswordAsync(user, forgotPasswordModel.Token, forgotPasswordModel.Password);
                if (!resetPassResult.Succeeded)
                {
                    foreach (var error in resetPassResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return Ok(ModelState);

                }
                return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = $"Password Has been changed" });
            }

            return StatusCode(StatusCodes.Status400BadRequest,
                new Response { Status = "Error", Message = $"Could not send link to email, please try again" });

        }


    }
}
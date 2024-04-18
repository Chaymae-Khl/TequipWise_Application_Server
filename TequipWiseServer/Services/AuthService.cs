using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyAvocatApi.Models;
using MyAvocatApi.Models.Authentication.SignIn;
using MyAvocatApi.Models.Authentication.SignUp;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TequipWiseServer.Interfaces;

namespace TequipWiseServer.Services
{
    public class AuthService : IAuthentication
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser, string role)
        {
            //checkUser Exist
            var userExist = await _userManager.FindByEmailAsync(registerUser.Email);
            if (userExist != null)
            {
                return new BadRequestObjectResult(new Response { Status = "Error", Message = "User already exists!" });
            }
            //Add the user in the database
            IdentityUser user = new()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.Username
            };

            if (await _roleManager.RoleExistsAsync(role))
            {
                var result = await _userManager.CreateAsync(user, registerUser.Password);
                if (!result.Succeeded)
                {
                    return new BadRequestObjectResult(new Response { Status = "Error", Message = "User failed to create!" });
                }

                //Assign a role  to the user
                await _userManager.AddToRoleAsync(user, role);
                return new OkObjectResult(new Response { Status = "Success", Message = "User created successfully!" });
            }
            else
            {
                return new BadRequestObjectResult(new Response { Status = "Error", Message = "This role does not exist." });
            }
        }

        public async Task<IActionResult> Login([FromBody] LoginModal loginmodal)
        {
            //checking the user
            var user = await _userManager.FindByNameAsync(loginmodal.Username);
            //checking the password
            if (user != null && await _userManager.CheckPasswordAsync(user, loginmodal.Password))
            {
                //claimlist creation
                var authClaims = new List<Claim>
           {
               new Claim(ClaimTypes.Name,user.UserName),
               new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
           };
                //we add roles to the list
                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                //generate the token with claims

                var jwtToken = GetToken(authClaims);

                // Return the token
                return new OkObjectResult(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    expiration = jwtToken.ValidTo
                });
            }

            // Return unauthorized if authentication fails
            return new UnauthorizedResult();


        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyAvocatApi.Models;
using MyAvocatApi.Models.Authentication.SignIn;
using MyAvocatApi.Models.Authentication.SignUp;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TequipWiseServer.Data;
using TequipWiseServer.DTO;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;
namespace TequipWiseServer.Services
{
    public class AuthService : IAuthentication
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IMapper mapper, AppDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _mapper = mapper;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<int> GetUserCount()
        {
            return await _userManager.Users.CountAsync();
        }
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser, string role)
        {
            
            // Check if the user already exists by email
            var userExistByEmail = await _userManager.FindByEmailAsync(registerUser.Email);
            if (userExistByEmail != null)
            {
                return new BadRequestObjectResult(new Response { Status = "Error", Message = "User with this email already exists!" });
            }
            // Create a new ApplicationUser instance and set its properties
            ApplicationUser user = new ApplicationUser
            {
                Email = registerUser.Email,
                UserName = registerUser.Username,
                TeNum = registerUser.TeNum,
                locaId = registerUser.locationID,
                DepartmentDeptId=registerUser.DeptId,
                plantId=registerUser.plantId,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            // Check if the specified role exists
            if (await _roleManager.RoleExistsAsync(role))
            {
                // Attempt to create the user
                var result = await _userManager.CreateAsync(user, registerUser.Password);
                if (result.Succeeded)
                {
                    // If user creation succeeds, assign the specified role to the user
                    await _userManager.AddToRoleAsync(user, role);
                    return new OkObjectResult(new Response { Status = "Success", Message = "User created successfully!" });
                }
                else
                {
                    // If user creation fails, return an error response
                    return new BadRequestObjectResult(new Response { Status = "Error", Message = "User failed to create!" });
                }
            }
            else
            {
                // If the specified role does not exist, return an error response
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


        public async Task<List<UserDetailsDTO>> GetUsers()
        {
            var users = await _userManager.Users
                .Include(u => u.Location)
                .Include(u => u.Department)
                .Include(u => u.Plant)
                .ToListAsync();

            var userDetailsList = new List<UserDetailsDTO>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var userDetails = _mapper.Map<UserDetailsDTO>(user);
                userDetails.Roles = roles.ToList();

                userDetailsList.Add(userDetails);
            }
            return userDetailsList;
        }

        // Method to delete a user by ID
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new NotFoundObjectResult(new Response { Status = "Error", Message = "User not found!" });
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return new OkObjectResult(new Response { Status = "Success", Message = "User deleted successfully!" });
            }
            else
            {
                return new BadRequestObjectResult(new Response { Status = "Error", Message = "Failed to delete user!" });
            }
        }

        public async Task<IActionResult> UpdateUser(string userId, UserDetailsDTO updatedUserDetails)
        {
            // Find the user by userId
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new NotFoundObjectResult(new Response { Status = "Error", Message = "User not found!" });
            }
            // Update user properties based on updatedUserDetails
            user.Email = updatedUserDetails.Email;
            user.TeNum = updatedUserDetails.TeNum;
            user.UserName = updatedUserDetails.UserName;

         

            // Find the backup approver by TeNum
            if (!string.IsNullOrEmpty(updatedUserDetails.Backupaprover_Name))
            {
                var backupApprover = await _userManager.Users.FirstOrDefaultAsync(u => u.TeNum == updatedUserDetails.Backupaprover_Name);
                if (backupApprover != null)
                {
                    user.Backupaprover = backupApprover;
                    user.BackupaproverId = backupApprover.Id;
                }
            }

            // Update the user in the database
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                // Update user roles
                var existingRoles = await _userManager.GetRolesAsync(user);
                var rolesToAdd = updatedUserDetails.Roles.Except(existingRoles);
                var rolesToRemove = existingRoles.Except(updatedUserDetails.Roles);

                // Retrieve department based on provided department name
                if (!string.IsNullOrEmpty(updatedUserDetails.DepartmentName))
                {
                    var department = await _dbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentName == updatedUserDetails.DepartmentName);
                    if (department != null)
                    {
                        user.Department = department;
                        user.DepartmentDeptId = department.DeptId;
                    }
                }
                // Retrieve department based on provided department name
                if (!string.IsNullOrEmpty(updatedUserDetails.LocationName))
                {
                    var location = await _dbContext.Location.FirstOrDefaultAsync(l => l.LocationName == updatedUserDetails.LocationName);
                    if (location != null)
                    {
                        user.Location = location;
                        user.locaId = location.LocationId;
                        _dbContext.Entry(location).State = EntityState.Modified; // Mark the entity as modified
                    }
                }
                if (!string.IsNullOrEmpty(updatedUserDetails.plant_name))
                {
                    var plant = await _dbContext.Plants.FirstOrDefaultAsync(l => l.plant_name == updatedUserDetails.plant_name);
                    if (plant != null)
                    {
                        user.Plant = plant;
                        user.plantId = plant.PlantNumber;
                    }
                }
                // Add new roles
                foreach (var role in rolesToAdd)
                {
                    await _userManager.AddToRoleAsync(user, role);
                }

                // Remove roles that are no longer assigned
                foreach (var role in rolesToRemove)
                {
                    await _userManager.RemoveFromRoleAsync(user, role);
                }
                await _dbContext.SaveChangesAsync();
                return new OkObjectResult(new Response { Status = "Success", Message = "User updated successfully!" });
            }
            else
            {
                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description).ToList();
                    // Log the errors or return them in the response
                    return new BadRequestObjectResult(new Response { Status = "Error", Message = string.Join("; ", errors) });
                }
                return new BadRequestObjectResult(new Response { Status = "Error", Message = "Failed to update user!" });
            }
        }
        public async Task<IActionResult> GetAllRoles()
        {
            // Retrieve all roles from RoleManager
            var roles = await _roleManager.Roles.ToListAsync();

            // Map roles to RoleDTO using AutoMapper
            var roleDTOs = _mapper.Map<List<RoleDTO>>(roles);

            return new OkObjectResult(roleDTOs);
        }
        public async Task<ApplicationUser> GetAuthenticatedUserAsync()
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            if (string.IsNullOrEmpty(userName))
            {
                return null; // No authenticated user
            }

            var user = await _userManager.FindByNameAsync(userName);
            return user;
        }
        public async Task<IActionResult> ChangeUserPassword(string userId, string newPassword)
        {
            // Find the user by userId
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new NotFoundObjectResult(new Response { Status = "Error", Message = "User not found!" });
            }

            // Generate a password reset token
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // Reset the user's password to the new password
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

            if (result.Succeeded)
            {
                return new OkObjectResult(new Response { Status = "Success", Message = "Password changed successfully!" });
            }
            else
            {
                // If password reset fails, return an error response
                return new BadRequestObjectResult(new Response { Status = "Error", Message = "Failed to change password." });
            }
        }
        public async Task<ApplicationUser?> GetAuthenticatedUser()
        {
            // Retrieve the user's identity from the current HttpContext
            var userClaims = _httpContextAccessor.HttpContext?.User;

            if (userClaims != null && userClaims.Identity?.IsAuthenticated == true)
            {
                // Extract the username from the claims
                var userName = userClaims.FindFirst(ClaimTypes.Name)?.Value;

                // Retrieve the user details from the database
                var user = await _userManager.FindByNameAsync(userName);
                return user;
            }

            // Return null if no authenticated user is found
            return null;
        }

    }
}

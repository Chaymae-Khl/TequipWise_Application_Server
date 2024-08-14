using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TequipWiseServer.Data;
using TequipWiseServer.DTO;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;
using User.Managmenet.Service.Models;
using User.Managmenet.Service.Services;

namespace TequipWiseServer.Services
{
    public class PhoneRequestService : IPhoneRequest
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAuthentication _authService;
        private readonly IEMailService _emailService;
        private readonly UserManager<ApplicationUser> _userManager;
        public PhoneRequestService(AppDbContext dbContext, IMapper mapper, IAuthentication authService, IEMailService emailService, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _authService = authService;
            _emailService = emailService;
            _userManager = userManager;
        }
        public string FixedemailLink = "http://localhost:4200/";



        public async Task<IActionResult> PassPhoneRequest(PhoneRequest request)
        {
            // Get the authenticated user details
            var userResult = await _authService.GetAuthenticatedUserAsync();

            if (userResult is UnauthorizedResult)
            {
                return new ObjectResult(new Response { Status = "Unauthorized", Message = "Authenticated user not retrieved!" });
            }

            var okResult = userResult as OkObjectResult;
            if (okResult == null || okResult.Value == null)
            {
                return new ObjectResult(new Response { Status = "Unauthorized", Message = "Authenticated user not retrieved!" });
            }

            var userDetails = okResult.Value as UserDetailsDTO;
            if (userDetails == null || userDetails.Department == null || userDetails.Department.Manager == null)
            {
                return new ObjectResult(new Response { Status = "Error", Message = "Authenticated user information not retrieved!" });
            }

            // Assign the request to the authenticated user
            request.UserId = userDetails.Id;
            // Set the actual date
            request.RequestDate = DateTime.Now;

            _dbContext.PhoneRequests.Add(request);
            await _dbContext.SaveChangesAsync();

            await SendEmailForApprovalAsync(userDetails);

            return new OkObjectResult(new Response { Status = "Success", Message = "Request passed successfully!" });
        }

        private async Task SendEmailForApprovalAsync(UserDetailsDTO userDetails)
        {
            var haveApprover = userDetails.ApproverActive;
            var haveBackupApprover = userDetails.ManagerBackupApproverActive;

            if (haveApprover == true)
            {
                var approverEmail = userDetails.ApproverEmail;
                if (string.IsNullOrEmpty(approverEmail))
                {
                    throw new Exception("Approver email is missing.");
                }

                var approver = await _userManager.FindByEmailAsync(approverEmail);
                if (approver != null)
                {
                    await SendEmailAsync(approver.Email, "PhoneRequestConfirmation");
                }
            }
            else if (haveBackupApprover == true)
            {
                var backupApproverEmail = userDetails.ManagerBackupApproverEmail;
                if (string.IsNullOrEmpty(backupApproverEmail))
                {
                    throw new Exception("Backup Approver email is missing.");
                }

                var manager = await _userManager.FindByEmailAsync(backupApproverEmail);
                if (manager != null)
                {
                    await SendEmailAsync(manager.Email, "PhoneRequestConfirmation");
                }
            }
            else
            {
                var deptmanagerEmail = userDetails.ManagerEmail;
                if (string.IsNullOrEmpty(deptmanagerEmail))
                {
                    throw new Exception("Department manager's email is missing.");
                }

                var manager = await _userManager.FindByEmailAsync(deptmanagerEmail);
                if (manager != null)
                {
                    await SendEmailAsync(manager.Email, "PhoneRequestConfirmation");
                }
            }
        }

        private async Task SendEmailAsync(string email, string linkAction)
        {
            var deptmangLink = FixedemailLink + linkAction;
            var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "RequestApprovalTemplate.html");
            var emailTemplate = await System.IO.File.ReadAllTextAsync(emailTemplatePath);
            var emailContent = emailTemplate.Replace("{{resetLink}}", deptmangLink);

            var message = new Message(new string[] { email }, "Equipment Request Confirmation Link", emailContent, isHtml: true);
            _emailService.SendEmail(message);
        }




        async public Task<IEnumerable<PhoneRequestDTO>> GetRequestsByUserIdAsync(string userId)
        {
            var requests = await _dbContext.PhoneRequests
       .Where(r => r.UserId == userId)
       .OrderByDescending(r => r.RequestDate)
       .Include(r => r.User)
       .Include(r=>r.HR)
       .Include(r=>r.DeparManag)
       .ToListAsync();

            return _mapper.Map<IEnumerable<PhoneRequestDTO>>(requests);
        }
    }
}

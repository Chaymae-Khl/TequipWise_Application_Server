using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TequipWiseServer.Data;
using TequipWiseServer.DTO;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;
using User.Managmenet.Service.Services;

namespace TequipWiseServer.Services
{
    public class PhoneRequestService : IPhoneRequest
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAuthentication _authService;
        private readonly IEMailService _emailService;

        public PhoneRequestService(AppDbContext dbContext, IMapper mapper, IAuthentication authService, IEMailService emailService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _authService = authService;
            _emailService = emailService;
        }

       

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

            return new OkObjectResult(new Response { Status = "Success", Message = "Request passed successfully!" });
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

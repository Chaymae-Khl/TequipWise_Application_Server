using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TequipWiseServer.Data;
using TequipWiseServer.DTO;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;


namespace TequipWiseServer.Services
{
    public class EquipementRequestService : IEquipementRequest
    {

        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public EquipementRequestService(AppDbContext dbContext, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IEnumerable<EquipementRequestDTO>> GetRequestsByUserIdAsync(string userId)
        {
            var requests = await _dbContext.UserEquipmentRequests
                .Where(r => r.UserId == userId)
                //.OrderByDescending(r => r.RequestDate)
                .Include(r => r.Equipment)
                .Include(r => r.User)
                .Include(r => r.IT)
                .Include(r => r.Controller)
                .Include(r => r.DeparManag)
                .ToListAsync();

            return _mapper.Map<IEnumerable<EquipementRequestDTO>>(requests);
        }

        public async Task<IActionResult> PassRequest(UserEquipmentRequest request)
        {
            request.RequestDate = DateTime.Now;
            _dbContext.UserEquipmentRequests.Add(request);
            await _dbContext.SaveChangesAsync();

            return new OkObjectResult(new Response { Status = "Success", Message = "Request passed successfully!" });
        }

        public async Task<int> GetRequestCountByUserIdAsync(string userId)
        {
            return await _dbContext.UserEquipmentRequests
                .CountAsync(r => r.UserId == userId);
        }

        // Get the requests of the department manager
        public async Task<IEnumerable<EquipementRequestDTO>> GetRequestsForDepartmentManagerAsync(string managerId)
        {
            var requests = await _dbContext.UserEquipmentRequests
                                           .Where(r => r.User.Department.ManagerId == managerId)
                                           .OrderByDescending(r => r.RequestDate)
                                           .Include(r => r.Equipment)
                                           .Include(r => r.User)
                                           .Include(r => r.IT)
                                           .Include(r => r.Controller)
                                           .Include(r => r.DeparManag)
                                           .ToListAsync();

            return _mapper.Map<IEnumerable<EquipementRequestDTO>>(requests);
        }
        public async Task<IEnumerable<EquipementRequestDTO>> GetRequestsForLocationITApproverAsync(string Itapproverid)
        {
            // Find the user and their associated plant
            var user = await _userManager.FindByIdAsync(Itapproverid);

            if (user == null || user.plantId == null)
            {
                return Enumerable.Empty<EquipementRequestDTO>();
            }

            var plantId = user.plantId.Value;

            // Retrieve the requests associated with the plant where the user is the IT approver
            var requests = await _dbContext.UserEquipmentRequests
                                           .Where(r => r.User.plantId == plantId)
                                           .OrderByDescending(r => r.RequestDate)
                                           .Include(r => r.Equipment)
                                           .Include(r => r.User)
                                           .Include(r => r.Controller)
                                           .Include(r => r.DeparManag)
                                           .ToListAsync();

            return _mapper.Map<IEnumerable<EquipementRequestDTO>>(requests);
        }
        public async Task<IActionResult> UpdateRequest(UserEquipmentRequest updatedRequest)
        {
            _dbContext.Entry(updatedRequest).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.UserEquipmentRequests.Any(e => e.UserEquipmentRequestId == updatedRequest.UserEquipmentRequestId))
                {
                    return new NotFoundResult();
                }
                else
                {
                    throw;
                }
            }

            return new OkObjectResult(new Response { Status = "Success", Message = "Request updated successfully!" });
        }

    }
}

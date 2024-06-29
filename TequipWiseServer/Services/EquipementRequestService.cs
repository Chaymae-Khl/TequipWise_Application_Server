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
            // Step 1: Find the plant IDs where the user is the IT approver
            var plantIds = await _dbContext.Plants
                                           .Where(p => p.ITApproverId == Itapproverid)
                                           .Select(p => p.PlantNumber)
                                           .ToListAsync();

            // Debug: Log or inspect plant IDs
            Console.WriteLine("Plant IDs where the user is IT approver:");
            foreach (var id in plantIds)
            {
                Console.WriteLine($"Plant ID: {id}");
            }

            // Check if plantIds is empty
            if (!plantIds.Any())
            {
                Console.WriteLine("No plant IDs found for the given IT approver.");
                return Enumerable.Empty<EquipementRequestDTO>();
            }

            // Step 2: Get the requests for those plants
            var requests = await _dbContext.UserEquipmentRequests
                                           .Where(r => r.User.plantId.HasValue && plantIds.Contains(r.User.plantId.Value))
                                           .OrderByDescending(r => r.RequestDate)
                                           .Include(r => r.Equipment)
                                           .Include(r => r.User)
                                           .Include(r => r.Controller)
                                           .Include(r => r.DeparManag)
                                           .ToListAsync();

            // Debug: Log or inspect requests count
            Console.WriteLine($"Total requests found: {requests.Count}");
            foreach (var request in requests)
            {
                Console.WriteLine($"Request ID: {request.UserEquipmentRequestId}, Plant ID: {request.User.plantId}");
            }

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

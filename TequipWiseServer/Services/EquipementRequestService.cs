using AutoMapper;
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

        public EquipementRequestService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper= mapper;
        }

        public async Task<IEnumerable<EquipementRequestDTO>> GetRequestsByUserIdAsync(string userId)
        {
            var requests = await _dbContext.UserEquipmentRequests
                .Where(r => r.UserId == userId)
                //.OrderByDescending(r => r.RequestDate)
                .Include(r => r.Equipment)
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
                                           .ToListAsync();

            return _mapper.Map<IEnumerable<EquipementRequestDTO>>(requests);
        }

}
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TequipWiseServer.Data;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;


namespace TequipWiseServer.Services
{
    public class EquipementRequestService : IEquipementRequest
    {

        private readonly AppDbContext _dbContext;
        public EquipementRequestService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IActionResult> PassRequest(UserEquipmentRequest request)
        {
            request.RequestDate = DateTime.Now;
            _dbContext.UserEquipmentRequests.Add(request);
            await _dbContext.SaveChangesAsync();

            return new OkObjectResult(new Response { Status = "Success", Message = "Request passed successfully!" });
        }
    }
}

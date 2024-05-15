using Microsoft.AspNetCore.Mvc;
using MyAvocatApi.Models;
using TequipWiseServer.Data;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;

namespace TequipWiseServer.Services
{
    public class PlantsDeptService: Iplantsdept
    {

        private readonly AppDbContext _dbContext;

        public PlantsDeptService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> AddPlant(Plant newPlant)
        {
            _dbContext.Plants.Add(newPlant);
            await _dbContext.SaveChangesAsync();
            return new OkObjectResult(new Response { Status = "Success", Message = "Plant Added successfully!" });

        }




    }

}


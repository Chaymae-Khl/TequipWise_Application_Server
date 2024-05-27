using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAvocatApi.Models;
using TequipWiseServer.Data;
using TequipWiseServer.DTO;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;

namespace TequipWiseServer.Services
{
    public class LocationService : ILocation
    {
        private readonly AppDbContext _dbContext;

        public LocationService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> CreateLocation(LocationDTO locationDto)
        {
            var newLocation = new Location
            {
                LocationName = locationDto.LocationName,
                BuildingNumber = locationDto.BuildingNumber
            };

            _dbContext.Location.Add(newLocation);
            await _dbContext.SaveChangesAsync();

            return new OkObjectResult(new Response { Status = "Success", Message = "Location Added successfully!" });
        }

        public async Task<IActionResult> AddPlant(Plant newPlant)
        {
            _dbContext.Plants.Add(newPlant);
            await _dbContext.SaveChangesAsync();
            return new OkObjectResult(new Response { Status = "Success", Message = "Plant Added successfully!" });

        }

    }
}

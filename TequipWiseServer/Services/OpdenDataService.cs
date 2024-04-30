using Microsoft.EntityFrameworkCore;
using TequipWiseServer.Data;
using TequipWiseServer.DTO;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;
using AutoMapper;
namespace TequipWiseServer.Services
{
    public class OpdenDataService : IOpenData
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public OpdenDataService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<IEnumerable<PlantDto>> GetPlants()
        {
            var plants = await _dbContext.Plants
                                 .Include(p => p.Departments)
                                 .ToListAsync();

            return _mapper.Map<IEnumerable<Plant>, IEnumerable<PlantDto>>(plants);
        }
    }
}


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


        public async Task<IEnumerable<LocationDTO>> GetPlants()
        {
            var locations = await _dbContext.Location
        .Include(l => l.LocationDepartments)
            .ThenInclude(ld => ld.Department)
            .ThenInclude(d => d.Manager)
        .Include(l => l.LocationPlants)
            .ThenInclude(lp => lp.Plant)
            .ThenInclude(p => p.Approver)
        .Include(l => l.LocationPlants)
            .ThenInclude(lp => lp.Plant)
            .ThenInclude(p => p.ItApprover) // Include the ITApprover property
        .AsNoTracking()
        .ToListAsync();

            return _mapper.Map<IEnumerable<Location>, IEnumerable<LocationDTO>>(locations);
        }
    }
}


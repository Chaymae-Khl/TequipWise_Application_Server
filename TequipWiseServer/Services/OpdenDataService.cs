using Microsoft.EntityFrameworkCore;
using TequipWiseServer.Data;
using TequipWiseServer.DTO;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
            //to give the request the time to be executed
            _dbContext.Database.SetCommandTimeout(60);
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


using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TequipWiseServer.Data;
using TequipWiseServer.DTO;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;

namespace TequipWiseServer.Services
{
    public class EquipementService : IEquipment
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper; 

        public EquipementService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<IEnumerable<EquipmentDTO>> GetEquipments()
        {

            var equipmentList = _dbContext.Equipments.Include(e => e.supplier).ToList();

            // Use AutoMapper to map Plant entities to PlantDto objects
            var equipmentslist = _mapper.Map<List<EquipmentDTO>>(equipmentList);

            return equipmentslist;


        }

        public async  Task<IActionResult> AddEquipment(Equipment equipment)
        {
            _dbContext.Equipments.Add(equipment);
            await _dbContext.SaveChangesAsync();
            return new OkObjectResult(equipment);
        }

        public async Task<int> GetEquipmentCount()
        {
            return await _dbContext.Equipments.CountAsync();
        }

        public async Task<IActionResult> RemoveEquipment(int id)
        {
            var equipement = await _dbContext.Equipments.FindAsync(id);
            if (equipement == null)
            {
                return new NotFoundResult();
            }

            _dbContext.Equipments.Remove(equipement);
            await _dbContext.SaveChangesAsync();
            return new NoContentResult();
        }

        public async Task<IActionResult> UpdateEquipemnt(int equipId, Equipment equipment)
        {
            var existingEquipment = await _dbContext.Equipments.FindAsync(equipId);
            if (existingEquipment == null)
            {
                return new NotFoundResult();
            }

            existingEquipment.EquipName = equipment.EquipName;
            existingEquipment.supplierrid = equipment.supplierrid;

            _dbContext.Equipments.Update(existingEquipment);
            await _dbContext.SaveChangesAsync();
            return new OkObjectResult(existingEquipment);
        }

        public async Task<List<dynamic>> GetEquipemntInfoAsync()
        {
            return await _dbContext.Equipments
                .AsNoTracking()
                .Select(e => new
                {
                    EquipementSN = e.EquipementSN,
                    EquipName = e.EquipName
                })
                .Cast<dynamic>()
                .ToListAsync();
        }
    }
}

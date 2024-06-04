using Microsoft.AspNetCore.Mvc;
using TequipWiseServer.DTO;
using TequipWiseServer.Models;

namespace TequipWiseServer.Interfaces
{
    public interface ILocation
    {
        Task<IActionResult> CreateLocation(LocationDTO locationDto);
        Task<IActionResult> DeleteLocation(int locationId);

        Task<IEnumerable<DepartmentDTO>> GetDepartments();
        Task<IEnumerable<PlantDto>> GetPlants();
        Task<IActionResult> AddPlantToLocation(int locationId, PlantDto plantDto);
        Task<IActionResult> UpdatePlantOfLocation(int locationId, int plantId, PlantDto plantDto);
        Task<IActionResult> DeletePlantofLocation(int locationId, int plantId);

        Task<IActionResult> AddDepartementToLocation(int locationId, DepartmentDTO departmentDto);
        Task<IActionResult> UpdateDepartementOfLocation(int locationId, int deptId, DepartmentDTO departmentDto);


    }
}

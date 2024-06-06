using Microsoft.AspNetCore.Mvc;
using TequipWiseServer.DTO;
using TequipWiseServer.Models;

namespace TequipWiseServer.Interfaces
{
    public interface IEquipment
    {
        Task<IEnumerable<EquipmentDTO>> GetEquipments();
        Task<IActionResult> AddEquipment(Equipment equipment);
        Task<int> GetEquipmentCount();

        Task<IActionResult> RemoveEquipment(int id);
        Task<IActionResult> UpdateEquipemnt(int equipId, Equipment equipment);
        Task<List<dynamic>> GetEquipemntInfoAsync();
    }
}

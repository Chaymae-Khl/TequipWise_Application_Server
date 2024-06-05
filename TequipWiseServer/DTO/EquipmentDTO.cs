using System.ComponentModel.DataAnnotations;
using TequipWiseServer.Models;

namespace TequipWiseServer.DTO
{
    public class EquipmentDTO
    {
        public int EquipementSN { get; set; }
        public string EquipName { get; set; }
        public string? supplierrid { get; set; }
        public string? supplierName { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using TequipWiseServer.Models;

namespace TequipWiseServer.DTO
{
    public class EquipementRequestDTO
    {
        [Required]
        public int UserEquipmentRequestId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int EquipmentId { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }
        [Required]
        public string Comment { get; set; }
        public virtual ApplicationUser? User { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TequipWiseServer.Models
{
    public class Equipment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EquipementSN { get; set; }

        [Required]
        public string EquipName { get; set; }

        public string? supplierrid { get; set; }
        [JsonIgnore]
        public Supplier? supplier { get; set; }


        public virtual ICollection<UserEquipmentRequest> UserEquipmentRequests { get; set; }

        
    }
}

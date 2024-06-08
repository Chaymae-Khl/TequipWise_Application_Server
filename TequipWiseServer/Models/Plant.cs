using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TequipWiseServer.Models
{
    public class Plant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlantNumber { get; set; }
        public string plant_name { get; set; }
        public string SapNumber { get; set; }

        public string? ApproverId { get; set; }
        public ICollection<ApplicationUser>? Users { get; set; }

        public ICollection<LocationPlant>? LocationPlants { get; set; }
        public ApplicationUser? Approver { get; set; }
    }
}

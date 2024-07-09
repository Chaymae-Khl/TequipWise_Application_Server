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

        //controller (Approver)

        //It Approver
        public string? ITApproverId { get; set; }


        public ICollection<ApplicationUser>? Users { get; set; }

        public ICollection<LocationPlant>? LocationPlants { get; set; }
        public ApplicationUser? ItApprover { get; set; }


    }
}

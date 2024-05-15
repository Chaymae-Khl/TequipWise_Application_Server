using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TequipWiseServer.Models
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int BuildingNumber { get; set; }

        public ICollection<LocationPlant> LocationPlants { get; set; }
        public ICollection<LocationDepartment> LocationDepartments { get; set; }
    }
}

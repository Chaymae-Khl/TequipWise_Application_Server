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
        public int BuildingNumber { get; set; }
        public string location { get; set; }
        public string Plant_Manager { get; set; }

        // Collection of departments in this plant
        public ICollection<Department>? Departments { get; set; }

        public Plant()
        {
           this.Departments = new List<Department>();
        }
    }
}

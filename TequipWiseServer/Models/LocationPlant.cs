using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TequipWiseServer.Models
{
    public class LocationPlant
    {
       
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int PlantId { get; set; }
        public Plant Plant { get; set; }
    }
}

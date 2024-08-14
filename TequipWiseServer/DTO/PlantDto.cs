using TequipWiseServer.Models;

namespace TequipWiseServer.DTO
{
    public class PlantDto
    {
        public int PlantNumber { get; set; }
        public string? plant_name { get; set; }

        public string? Location { get; set; }
  
        public string? ITApproverId { get; set; }
        public string? ITApprover_name { get; set; }
        public string? HrApproverId { get; set; }

        public string? HrApprover_name { get; set; }

    }
}

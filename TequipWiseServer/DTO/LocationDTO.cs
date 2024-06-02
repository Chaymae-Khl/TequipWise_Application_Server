namespace TequipWiseServer.DTO
{
    public class LocationDTO
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int BuildingNumber { get; set; }

        public List<DepartmentDTO>? Departments { get; set; }
        public List<PlantDto>? Plants { get; set; }


    }
}

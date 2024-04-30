namespace TequipWiseServer.DTO
{
    public class PlantDto
    {
        

        public int PlantNumber { get; set; }
        public int BuildingNumber { get; set; }
        public string Location { get; set; }
        public string Plant_Manager { get; set; }
        public List<DepartmentDTO> Departments { get; set; }
    }
}

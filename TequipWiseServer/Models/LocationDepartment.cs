namespace TequipWiseServer.Models
{
    public class LocationDepartment
    {
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}

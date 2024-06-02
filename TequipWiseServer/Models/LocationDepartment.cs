namespace TequipWiseServer.Models
{
    public class LocationDepartment
    {
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string? ManagerId { get; set; }
        public ApplicationUser? Manager { get; set; }

    }
}

namespace TequipWiseServer.DTO
{
    public class UserDetailsDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string TeNum { get; set; }

        public string? plant_name { get; set; }
        public string? Backupaprover_Name { get; set; }
        public string? ManagerName { get; set; }

        public List<string> Roles { get; set; }
        public string DepartmentName { get; set; }

        public string? LocationName { get; set; }
        
    }
}

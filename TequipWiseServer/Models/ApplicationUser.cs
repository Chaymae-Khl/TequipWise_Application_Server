using Microsoft.AspNetCore.Identity;

namespace TequipWiseServer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? TeNum { get; set; }

        public string? ManagerId { get; set; }

        public int? DepartmentDeptId { get; set; }
        public Department? Department { get; set; } // Assuming Department is your related entity

    }
}

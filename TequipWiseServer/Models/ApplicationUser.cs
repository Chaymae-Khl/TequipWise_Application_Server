using Microsoft.AspNetCore.Identity;

namespace TequipWiseServer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? TeNum { get; set; }
        public bool? StatusBackupProvider { get; set; }
        public string? BackupaproverId { get; set; }
        public int? DepartmentDeptId { get; set; }
        public Department? Department { get; set; } // Assuming Department is your related entity
        public ApplicationUser? Backupaprover { get; set; } //the person that will aprove the request when the it analyst is not availble

    }
}

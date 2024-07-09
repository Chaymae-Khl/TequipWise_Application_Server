using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Text.Json.Serialization;

namespace TequipWiseServer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? TeNum { get; set; }
        public bool? StatusBackupProvider { get; set; }

        //those infos is in case the user is in vaction so he need to active the backup approver to approve in his place
        public bool? backupActive { get; set; }
        public string? BackupaproverId { get; set; }
        public ApplicationUser? Backupaprover { get; set; } //the person that will aprove the request when

        //those infos is in case there is a an external approver have to approve for somebody
        public bool? ApproverActive { get; set; }
        public string? ManagerId { get; set; }
        public ApplicationUser? Manager { get; set; }



        public int? locaId { get; set; }
        public Location? Location { get; set; }

        public int? DepartmentDeptId { get; set; }
        public Department? Department { get; set; } // Assuming Department is your related entity
        public int? plantId { get; set; }
        public Plant? Plant { get; set; }

        public int? SapNumberId { get; set; } // Foreign key to SapNumber
        public SapNumber? SapNumber { get; set; } // Navigation property


        public virtual ICollection<ApplicationUser>? Subordinates { get; set; }

        public virtual ICollection<UserEquipmentRequest>? UserEquipmentRequests { get; set; }
        public virtual ICollection<UserEquipmentRequest>? ItRequestToApprove { get; set; }
        public virtual ICollection<UserEquipmentRequest>? ControllerRequestToApprove { get; set; }
        public virtual ICollection<UserEquipmentRequest>? DeptMangRequestToApprove { get; set; }

    }
}
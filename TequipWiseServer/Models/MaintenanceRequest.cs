using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TequipWiseServer.Models
{
    public class MaintenanceRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaintenanceId { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }

        public string? description { get; set; }
        public bool? RequestStatus { get; set; } = null;

        public string? equipmentType { get; set; }
        public string? sn { get; set; }
        public string? damageTYpe { get; set; }
        public string? offer { get; set; }

        public string? supplierId { get; set; }
        public string? UserId { get; set; }
        public string? deptManagId { get; set; }
        public string? itId { get; set; }
        public string? ControllerId { get; set; }

        //departmenent manager request part

        public DateTime? DepartmangconfirmedAt { get; set; }
        public bool? DepartmangconfirmStatus { get; set; } = null;

        public string? Departmang_Not_confirmCause { get; set; }

        //It manager request part

        public DateTime? ITconfirmedAt { get; set; }
        public bool? ITconfirmSatuts { get; set; } = null;

        public string? IT_Not_confirmCause { get; set; }


        public float? PU { get; set; } = 0;
        public string? GL { get; set; }

        public string? CC { get; set; }
        public string? order { get; set; }
        public string? PONum { get; set; }

        public string? PRNum { get; set; }

        public bool? PR_Status { get; set; } = null;
        public string? PR_Not_ConfirmCause { get; set; }


        //controller request part

        public DateTime? ControllerconfirmedAt { get; set; }
        public bool? ControllerconfirmSatuts { get; set; } = null;

        public string? Controller_Not_confirmCause { get; set; }

        //navigation
        [JsonIgnore]
        public Supplier? supplier { get; set; }
        [JsonIgnore]
        public virtual ApplicationUser? User { get; set; }
        [JsonIgnore]
        public virtual ApplicationUser? IT { get; set; }
        [JsonIgnore]
        public virtual ApplicationUser? DeptMnag { get; set; }
        [JsonIgnore]
        public virtual ApplicationUser? Controller { get; set; }
    }
}

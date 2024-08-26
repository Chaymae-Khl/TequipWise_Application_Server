using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TequipWiseServer.Models
{
    public class PhoneRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PhoneRequestId { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        public string? Comment { get; set; }


        //if is confirmed by all the actor the requestStatus is confirmed
        public bool? RequestStatus { get; set; } = null;

        public string? ForWho { get; set; }

        public string? NewHireName { get; set; }
        public string? NewHireEmail { get; set; }

        public string? AssetType { get; set; }
        public string? phoneRequestType { get; set; }
        public string? ReplacemnetType { get; set; }
       

        //foreing keys
        public string? UserId { get; set; }
        public string? deptManagId { get; set; }
        public string? itId { get; set; }
        public string? HRId { get; set; }



        //departmenent manager request part

        public DateTime? DepartmangconfirmedAt { get; set; }
        public bool? DepartmangconfirmStatus { get; set; } = null;

        public string? Departmang_Not_confirmCause { get; set; }

        //It manager request part

        public DateTime? ITconfirmedAt { get; set; }
        public bool? ITconfirmSatuts { get; set; } = null;

        public string? IT_Not_confirmCause { get; set; }
        public string? IMI { get; set; }
        public string? Modele { get; set; }
        public string? TelNumber { get; set; }
        public DateTime? AssetReceiveByEMployeAt { get; set; }
        public bool? ReceptionStatus { get; set; } = null;

        //HR request part
        public DateTime? HRconfirmedAt { get; set; }
        public bool? HRconfirmSatuts { get; set; } = null;

        public string? HR_Not_confirmCause { get; set; }
        public string? EmployeeCategorie { get; set; }



        [JsonIgnore]
        public virtual ApplicationUser? User { get; set; }
        [JsonIgnore]
        public virtual ApplicationUser? DeparManag { get; set; }
        [JsonIgnore]
        public virtual ApplicationUser? IT { get; set; }
        [JsonIgnore]
        public virtual ApplicationUser? HR { get; set; }
    }
}

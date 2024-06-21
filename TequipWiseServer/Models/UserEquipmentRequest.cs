using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TequipWiseServer.Models
{
    public class UserEquipmentRequest
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserEquipmentRequestId { get; set; }
        public string? UserId { get; set; }
        [Required]
        public int EquipmentId { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }
        [Required]
        public string Comment { get; set; }

        //the approver iDS
        public string? deptManagId { get; set; }
        public string? itId {  get; set; }
        //the finance approver
        public string? controllerid { get; set; }


        //if is confirmed by all the actor the requestStatus is confirmed
        public bool? RequestStatus { get; set; }

        public bool? isNewhire { get; set; } = false;

        public int? NumberEquipment { get; set; }

        //departmenent manager request part

        public DateTime? DepartmangconfirmedAt { get; set; }
        public bool? DepartmangconfirmStatus { get; set; } = false;

        public string? Departmang_Not_confirmCause { get; set; }

        //Finance request part (Controller)
        public DateTime? FinanceconfirmedAt { get; set; }
        public bool? FinanceconfirmSatuts { get; set; } = false;

        public string? Finance_Not_confirmCause { get; set; }
        public string? GL { get; set; }

        public string? CC { get; set; }
        public string? order { get; set; }


        //IT request part
        public DateTime? ITconfirmedAt { get; set; }
        public bool? ITconfirmSatuts { get; set; } = false;

        public string? IT_Not_confirmCause { get; set; }

        //is a pdf file
        public string? SupplierOffer {  get; set; }

        public string? PONum {  get; set; }

        public string? PRNum { get; set; }

        public bool? PR_Status { get; set; } = false;
        public string? PR_Not_ConfirmCause { get; set; }

        // Navigation properties

        [JsonIgnore]
        public virtual ApplicationUser? User { get; set; }


        [JsonIgnore]
        public virtual ApplicationUser? DeparManag { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser? IT { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser? Controller { get; set; }

        [JsonIgnore]
        public virtual Equipment? Equipment { get; set; }
    }
}

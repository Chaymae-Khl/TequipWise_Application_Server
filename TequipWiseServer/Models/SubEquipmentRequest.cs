using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TequipWiseServer.Models
{
    public class SubEquipmentRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubEquipmentRequestId { get; set; }
        
        [Required]
        public DateTime SubRequestDate { get; set; }
        [Required]
        public string Comment { get; set; }

        //prix unitaire
        public float? PU { get; set; }

        public float Totale { get; set; }
        //the approver iDS
        public string? deptManagId { get; set; }
        public string? itId { get; set; }
        //the finance approver
        public string? controllerid { get; set; }


        //if is confirmed by all the actor the requestStatus is confirmed
        public bool? SubRequestStatus { get; set; } = null;

        //quantity of equipement
        public int? QtEquipment { get; set; }

        //departmenent manager request part

        public DateTime? DepartmangconfirmedAt { get; set; }
        public bool? DepartmangconfirmStatus { get; set; } = null;

        public string? Departmang_Not_confirmCause { get; set; }

        //Finance request part (Controller)
        public DateTime? FinanceconfirmedAt { get; set; }
        public bool? FinanceconfirmSatuts { get; set; } = null;

        public string? Finance_Not_confirmCause { get; set; }
      


        //IT request part
        public DateTime? ITconfirmedAt { get; set; }
        public bool? ITconfirmSatuts { get; set; } = null;

        public string? IT_Not_confirmCause { get; set; }

        //forein keys

        public int? RequestId { get; set; }
        [Required]
        public int EquipmentId { get; set; }

        // Navigation properties

        [JsonIgnore]
        public virtual EquipmentRequest? EquipRequest { get; set; }

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

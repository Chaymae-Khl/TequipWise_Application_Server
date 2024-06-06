using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TequipWiseServer.Models
{
    public class UserEquipmentRequest
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserEquipmentRequestId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int EquipmentId { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }
        [Required]
        public string Comment { get; set; }

        //if is confirmed by all the actor the requestStatus is confirmed
        public bool? RequestStatus { get; set; }

        public string? NewhireName { get; set; }

        public int? NumberEquipment { get; set; }

        //departmenent manager request part

        public DateTime? DepartmangconfirmedAt { get; set; }
        public bool? DepartmangconfirmStatus { get; set; }

        public string? Departmang_Not_confirmCause { get; set; }

        //Finance request part (Controller)
        public DateTime? FinanceconfirmedAt { get; set; }
        public bool? FinanceconfirmSatuts { get; set; }

        public string? Finance_Not_confirmCause { get; set; }

        //IT request part
        public DateTime? ITconfirmedAt { get; set; }
        public bool? ITconfirmSatuts { get; set; }

        public string? IT_Not_confirmCause { get; set; }

        public string? SupplierOffer {  get; set; }

        public string? PONum {  get; set; }

        public string? PRNum { get; set; }

        public string? GL { get; set; }

        public string? CC { get; set; }

        // Navigation properties
        public virtual ApplicationUser User { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}

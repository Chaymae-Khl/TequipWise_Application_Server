using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TequipWiseServer.Models;

namespace TequipWiseServer.DTO
{
    public class EquipementRequestDTO
    {
        [Required]
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

        public bool? isNewhire { get; set; }

        public int? NumberEquipment { get; set; }

        //departmenent manager request part

        public DateTime? DepartmangconfirmedAt { get; set; }
        public bool? DepartmangconfirmStatus { get; set; }

        public string? Departmang_Not_confirmCause { get; set; }

        //Finance request part (Controller)
        public DateTime? FinanceconfirmedAt { get; set; }
        public bool? FinanceconfirmSatuts { get; set; }

        public string? Finance_Not_confirmCause { get; set; }
        public string? GL { get; set; }

        public string? CC { get; set; }
        public string? order { get; set; }


        //IT request part
        public DateTime? ITconfirmedAt { get; set; }
        public bool? ITconfirmSatuts { get; set; }

        public string? IT_Not_confirmCause { get; set; }

        //is a pdf file
        public string? SupplierOffer { get; set; }

        public string? PONum { get; set; }

        public string? PRNum { get; set; }

        public bool? PR_Status { get; set; }
        public string? PR_Not_ConfirmCause { get; set; }

        public string EquipmentName { get; set; }

        [JsonIgnore]
        public Equipment Equipment { get; set; }
        [JsonIgnore]
        public virtual ApplicationUser? User { get; set; }
    }
}

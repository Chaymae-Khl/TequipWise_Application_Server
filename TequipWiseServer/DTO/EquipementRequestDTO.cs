using System.ComponentModel.DataAnnotations;
using TequipWiseServer.Models;

namespace TequipWiseServer.DTO
{
    public class EquipementRequestDTO
    {
        public int EquipmentRequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public string? Comment { get; set; }
        public float? TotalPrice { get; set; }

        public bool? RequestStatus { get; set; } = null;

        public bool? isNewhire { get; set; } = false;

        public string? NewHireName { get; set; }

        public string? GL { get; set; }

        public string? CC { get; set; }
        public string? order { get; set; }

        public string? SupplierOffer { get; set; }

        public string? PONum { get; set; }

        public string? PRNum { get; set; }

        public bool? PR_Status { get; set; } = null;
        public string? PR_Not_ConfirmCause { get; set; }

        public string? NmaeOfUser { get; set; }
        public string? SapNumOfUser { get; set; }
        public virtual ICollection<EquipementSUBrequestDTO>? EquipmentSubRequests { get; set; }


    }
}

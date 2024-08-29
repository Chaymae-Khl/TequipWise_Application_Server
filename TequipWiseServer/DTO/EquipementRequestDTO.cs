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

        public string? ForWho { get; set; }
        public string? currency { get; set; }

        public string? NewHireName { get; set; }



        public string? SupplierOffer { get; set; }

       

        public string? NmaeOfUser { get; set; }
        public string? SapNumOfUser { get; set; }
        public virtual ICollection<EquipementSUBrequestDTO>? EquipmentSubRequests { get; set; }


    }
}

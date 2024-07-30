using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TequipWiseServer.Models
{
    public class EquipmentRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EquipmentRequestId { get; set; }
       
        [Required]
        public DateTime RequestDate { get; set; }
     
        public string? Comment { get; set; }

        public float? TotalPrice { get; set; } = 0;

        //if is confirmed by all the actor the requestStatus is confirmed
        public bool? RequestStatus { get; set; } = null;

        public bool? isNewhire { get; set; } = false;

        public string? NewHireName { get; set; }
       
        public string? currency {  get; set; }


        //is a pdf file
        public string? SupplierOffer { get; set; }

    

        //foreing keys
        public string? UserId { get; set; }


        public virtual ICollection<SubEquipmentRequest>? EquipmentSubRequests { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser? User { get; set; }
        

    }
}

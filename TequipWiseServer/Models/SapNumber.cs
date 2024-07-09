using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TequipWiseServer.Models
{
    public class SapNumber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? SApID { get; set; }

        public string? SapNum { get; set; }


        //controller (Finance Approver)
        public string? Idcontroller { get; set; }

        [JsonIgnore]
        public ApplicationUser? Controller { get; set; }

        [JsonIgnore]

        public virtual ICollection<ApplicationUser>? Users { get; set; } // Collection of users that belong to this SapNumber


    }
}

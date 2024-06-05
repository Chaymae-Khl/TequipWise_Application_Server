using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TequipWiseServer.Models
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? SuplierId {  get; set; }

        public string? suuplier_name { get; set; }
        public string? address { get; set; }
        public string? email { get; set; }

        public ICollection<Equipment> Equipements { get; set; }

    }
}

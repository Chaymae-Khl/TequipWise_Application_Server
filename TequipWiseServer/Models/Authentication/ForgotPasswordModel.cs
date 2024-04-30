using System.ComponentModel.DataAnnotations;

namespace TequipWiseServer.Models.Authentication
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

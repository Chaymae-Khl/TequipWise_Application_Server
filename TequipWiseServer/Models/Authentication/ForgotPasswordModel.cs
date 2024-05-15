using System.ComponentModel.DataAnnotations;

namespace TequipWiseServer.Models.Authentication
{
    public class ForgotPasswordModel
    {
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Token { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
        [Compare("Password", ErrorMessage = "The password and the confirmation password de not match.")]
        public string ConfirmPassword { get; set; } = null!;



    }
}

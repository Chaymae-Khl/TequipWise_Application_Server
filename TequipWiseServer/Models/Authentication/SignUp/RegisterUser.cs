using System.ComponentModel.DataAnnotations;

namespace MyAvocatApi.Models.Authentication.SignUp
{
    public class RegisterUser

    {
        [Required]
        public string? TeNum { get; set; }
        [Required(ErrorMessage ="User Name is required")]
        public string? Username { get; set; }
        [EmailAddress]
        [Required(ErrorMessage ="Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage ="password is required")]
        public string? Password { get; set; }

        public int? DepartmentDeptId {  get; set; }
    }
}

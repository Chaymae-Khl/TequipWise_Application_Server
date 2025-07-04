﻿using System.ComponentModel.DataAnnotations;

namespace TequipWiseServer.Models.Authentication.SignIn
{
    public class LoginModal
    {
        [Required(ErrorMessage="User Name required")]
        public string? Username { get; set; }

        [Required(ErrorMessage ="Password is required")]
        public string? Password { get; set; } 
    }
}

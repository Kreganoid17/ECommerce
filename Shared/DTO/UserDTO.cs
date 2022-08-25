using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Shared.DTO
{
    public class UserDTO
    {
        [Required]
        public string Username  { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Compare(nameof(ConfirmPassword), ErrorMessage = "Password Doesnt Match")]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Confirm Password Doesnt Match")]
        public string ConfirmPassword   { get; set; }

    }
}

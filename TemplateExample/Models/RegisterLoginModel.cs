using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BayviewHouse.Models
{
    public class RegisterLoginModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password required")]
        [StringLength(10, ErrorMessage = "Password must contain 5 to 10 characters", MinimumLength = 5)]
        public string Password { get; set; }

        public UserRole UserRole { get; set; }
    }
}
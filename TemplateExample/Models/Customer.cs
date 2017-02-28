using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace BayviewHouse.Models
{
    public class Customer
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "First Name must contain alphabets")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Last Name must contain alphabets")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone number required")]
        public string Phone { get; set; }


        //[DataType(DataType.Password)]
        //[Required(ErrorMessage = "The password address is required")]
        //[StringLength(10, ErrorMessage = "Password must contain 5 to 10 characters", MinimumLength = 5)]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm Password")]
        //[Required]
        //[Compare("Password")]
        public string PasswordConfirm { get; set; }
    }
}
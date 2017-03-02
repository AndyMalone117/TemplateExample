using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Text.RegularExpressions;

namespace BayviewHouse.Models
{
    public class Customer_Model
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "First Name must contain alphabets")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Last Name must contain alphabets")]
        public string LastName { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone number required")]
        public string Phone { get; set; }
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password Required")]
        [StringLength(10, ErrorMessage = "Password must contain 5 to 10 characters", MinimumLength = 5)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password")]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }

        public Customer_Model() { }

        public Customer_Model(string firstName, string lastName, string email, string phone, string password, string passwordConfirm)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Password = password;
            PasswordConfirm = passwordConfirm;
        } 
        public bool Validate()
        {
            bool valid = false;

            string emailRegEx = ConfigurationManager.AppSettings["EmailRegEx"];

            int firstNameLength = 0;
            int.TryParse(ConfigurationManager.AppSettings["firstNameLength"], out firstNameLength);

            int lastNameLength = 0;
            int.TryParse(ConfigurationManager.AppSettings["lastNameLength"], out lastNameLength);

            int phoneLength = 0;
            int.TryParse(ConfigurationManager.AppSettings["PhoneLength"], out phoneLength);

            int passwordLength = 0;
            int.TryParse(ConfigurationManager.AppSettings["PasswordLength"], out passwordLength);

            int passwordConfirmLength = 0;
            int.TryParse(ConfigurationManager.AppSettings["PasswordLength"], out passwordConfirmLength);

            if (Regex.IsMatch(Email, emailRegEx) && FirstName.Length >= firstNameLength && LastName.Length >= lastNameLength && Phone.Length >= phoneLength && Password.Length >= passwordLength && PasswordConfirm.Length >= passwordConfirmLength)
            {
                valid = true;
            }
            return valid;
        }
    }
}
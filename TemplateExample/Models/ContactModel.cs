using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BayviewHouse.Models
{
    public class ContactModel
    {
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Booking Reference Required")]
        public string BookingRef { get; set; }

        [Required(ErrorMessage = "Topic Required")]
        public string Topic { get; set; }

        [Required(ErrorMessage = "Comments Required")]
        public string Comments { get; set; }

        [Required(ErrorMessage = "Answer Required")]
        public string Stay { get; set; }

        [Required(ErrorMessage = "Answer Required")]
        public string Recommend { get; set; }
        public DateTime Time { get; set; }
    }
}
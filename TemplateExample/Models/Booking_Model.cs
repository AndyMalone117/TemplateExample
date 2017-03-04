using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Text.RegularExpressions;
using static BayviewHouse.Controllers.BookingController;

namespace BayviewHouse.Models
{
    public class Booking_Model
    {
        [Display(Name = "Booking ID")]
        public int BookingId { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Room Name")]
        [Required(ErrorMessage ="Room Selection Required")]
        public string RoomName { get; set; }

        [Display(Name = "Arrival Date")]
        [Required(ErrorMessage ="Arrival Date Required")]
        [DataType(DataType.Date)]
        public DateTime? ArrivalDate { get; set; }

        [Display(Name = "Departure Date")]
        [Required(ErrorMessage ="Departure Date Required")]
        [DataType(DataType.Date)]
        public DateTime? DepartureDate { get; set; }

        [Display(Name = "Card Holder Name")]
        [Required(ErrorMessage ="Card Holder Name Required")]
        //[RegularExpression("^[a-z]+$", ErrorMessage = "Invalid Card Holder Name")]
        public string CardHolderName { get; set; }

        [Display(Name = "Card Type")]
        [Required(ErrorMessage ="Card Type Required")]
        public string CardType { get; set; }

        [Display(Name = "Card Number")]
        [Required(ErrorMessage ="Card Number Required")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid Card Number")]
        //[RegularExpression(@"^\d{16}$", ErrorMessage = "Invalid Card Number")]
        public string CreditCardNumber { get; set; }

        [Display(Name = "Expiry Date")]
        [Required(ErrorMessage ="Card Expiry Date Required")]
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }

        [Display(Name = "CVV")]
        [Required(ErrorMessage ="CVV Security Number Required")]
        [RegularExpression("^[0-9]+$", ErrorMessage ="Invalid CVV Security Number")]
        public int SecurityNumber { get; set; }    
 
    }
}
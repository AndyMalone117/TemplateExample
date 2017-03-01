using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BayviewHouse.Models
{
    public class Booking_Model
    {
        public int BookingID { get; set; }
        public int RoomID { get; set; }
        //MW added this 3/1/2017 5pm to remove error
        public string Email { get; set; }

        [Display(Name = "Room Name")]
        public string RoomName { get; set; }

        [Display(Name = "Arrival Date")]
        [DataType(DataType.Date)]
        public DateTime? ArrivalDate { get; set; }
        [Display(Name = "Departure Date")]
        [DataType(DataType.Date)]
        public DateTime? DepartureDate { get; set; }

        [Display(Name = "Card Number")]
        public string CreditCardNumber { get; set; }

        [Display(Name = "Expiry Date")]
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }

        [Display(Name = "Card Type")]
        public string CardType { get; set; }

        [Display(Name = "CVV")]
        public int SecurityNumber { get; set; }

        [Display(Name = "Card Holder Name")]
        public string CardHolderName { get; set; }

    

        public Booking_Model() { }
        public Booking_Model(int bookingID, int roomID, string email, string roomName, DateTime arrivalDate, DateTime departureDate, string cardType, string creditCardNumber, DateTime expiryDate , string cardHolderName ,int securityNumber)
        {
            BookingID = bookingID;
            RoomID = roomID;
            Email = email;
            RoomName = roomName;
            ArrivalDate = arrivalDate;
            DepartureDate = departureDate;
            CardHolderName = cardHolderName;
            CardType = cardType;
            CreditCardNumber = creditCardNumber;
            ExpiryDate = expiryDate;
            SecurityNumber = securityNumber;
        }
    }
}
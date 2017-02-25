using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BayviewHouse.Models
{
    public class CustomerTour_Model
    {
        public int CustomerTourID { get; set; }
        public int TourID { get; set; }
        [Display(Name = "Tour Name")]
        public string TourName { get; set; }
        public int CustomerID { get; set; }
        public DateTime DateOfTour { get; set; }
        [Display(Name = "Number Of People")]
        public int NumberOfPeople { get; set; }

        public int PricePerPerson { get; set; }

        public double TotalPrice { get; set; }

        public CustomerTour_Model(int customerTourID, int tourID, int customerID, DateTime dateOfYear, int numberOfPeople, string tourName,int pricePerPerson, double totalPrice)
        {
            CustomerTourID = customerTourID;
            TourID = tourID;
            CustomerID = customerID;
            NumberOfPeople = numberOfPeople;
            DateOfTour = dateOfYear;
            TotalPrice = totalPrice;
            PricePerPerson = pricePerPerson;
            TourName = tourName;
        }

        public void Price()
        {
            TotalPrice = NumberOfPeople * PricePerPerson;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BayviewHouse.Models
{
    public class Tour_Model
    {
        public int TourID { get; set; }
        public int CompanyID { get; set; }
        public string TourArea { get; set; }
        public int TimeDurationMins { get; set; }
        public decimal PricePerPerson { get; set; }

        public Tour_Model() { }

        public Tour_Model(int tourID, int companyID, string tourArea, int timeDurationsMins, int pricePerPerson)
        {
            TourID = tourID;
            CompanyID = companyID;
            TourArea = tourArea;
            TimeDurationMins = timeDurationsMins;
            PricePerPerson = pricePerPerson;
        }
    }
}
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
        [Display(Name = "Tour Name")]
        public string TourArea { get; set; }

        public string Email { get; set; }

        public int CustomerID { get; set; }

        [Display(Name = "Tour Date")]
        [DataType(DataType.Date)]
        public DateTime DateOfTour { get; set; }

        [Display(Name = "Number Of People")]
        public int NumberOfPeople { get; set; }



    }
}
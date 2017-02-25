using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BayviewHouse.Models
{
    public class TourCompany_Model
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CAddress { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public TourCompany_Model() { }

        public TourCompany_Model(int companyID, string companyName, string cAddress, string email, string phone)
        {
            CompanyID = companyID;
            CompanyName = companyName;
            CAddress = cAddress;
            Email = email;
            Phone = phone;
        }
    }
}
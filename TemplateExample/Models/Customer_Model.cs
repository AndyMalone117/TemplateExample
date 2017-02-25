using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BayviewHouse.Models
{
    public class Customer_Model
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CardHolderName { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public int CardExMonth { get; set; }
        public int CardExYear { get; set; }
        public int SecurityNumber { get; set; }

        public Customer_Model() { }

        public Customer_Model(int customerID, string firstName, string lastName, string email, string phone
            , string cardHolderName, string cardType, string cardNumber, int cardExMonth, int cardExYear, int securityNumber)
        {
            CustomerID = customerID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            CardHolderName = cardHolderName;
            CardType = cardType;
            CardNumber = cardNumber;
            CardExMonth = cardExMonth;
            CardExYear = cardExYear;
            SecurityNumber = securityNumber;
        }
    }
}
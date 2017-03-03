using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BayviewHouse.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace BayviewHouse.Controllers
{
    public class BookingController : Controller
    {
        DAO dao;

        // GET: Booking
        public ActionResult Index()
        {

            ViewData["RoomName"] = GetRoomNamesList();
            return View();
        }
        private List<string> GetRoomNamesList()
        {
            dao = new DAO();


            List<string> rooms = dao.PopulateRooms();
            return rooms;
        }
        [HttpGet]
        public ActionResult Booking()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBooking(Booking_Model booking)
        {

            ViewData["RoomName"] = GetRoomNamesList();

            string userCardInput = booking.CreditCardNumber;

            int count = 0;            
            if (ModelState.IsValid)
            {
                count = dao.InsertBooking(booking);
                if (count == 1)
                {
                    TempData["Message"] = "Booking Confirmed";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["message"] = dao.message;
                }
                return View("Index");

            }
            else return View("AddBooking", booking);

}
        //means of checking the validity of a credit card number using LINQ
        //Resourcehttps://bitlush.com/blog/luhn-validation-for-asp-net-web-forms-and-mvc       
        public static bool IsCardValid(string cardNumber, bool allowSpaces = false)
        {
            if (allowSpaces)
            {
                cardNumber = cardNumber.Replace(" ", "");
            }
            if (cardNumber.Any(m => !Char.IsDigit(m)))
            {
                return false;
            }
            int checksum = cardNumber.Select((m, i) => (m - '0') << ((cardNumber.Length - i - 1) & 1)).Sum(n => n > 9 ? n - 9 : n);

            return (checksum % 10) == 0 && checksum > 0;
        }
    }

    public class cardValidator
    {
        private static int[] userInput;
        //test
        //test2

        public static void cleanInput(string input) => userInput = input.Where(_ => !char.Equals(_, ' ') && char.IsDigit(_)).Reverse()
            .Select(_ => int.Parse(_.ToString())).ToArray();

        private static void MultiplyValues()
        {
            for (int i = 0; i < userInput.Length; i++)
            {
                if (i % 2 != 0)
                {
                    userInput[i] *= 2;
                }
            }
        }
        private static int AddValues()
        {
            var sum = default(int);
            for (int i = 0; i < userInput.Length; i++)
            {
                if (userInput[i] > 9)
                {
                    foreach (var character in userInput)
                    {
                        sum += int.Parse(character.ToString());
                    }
                    continue;
                }
                sum += userInput[i];
            }
            return sum;
        }
        public static bool Validate(string input)
        {
            cleanInput(input);
            MultiplyValues();
            return AddValues() % 10 == 0;
        }
    }
}

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
        [HttpGet]
        public ActionResult Booking()
        {
            return View();
        }

        private List<string> GetRoomNamesList()
        {
            dao = new DAO();

            List<string> rooms = dao.PopulateRooms();
            return rooms;
        }
        [HttpPost]
        public ActionResult Booking(Booking_Model booking)
        {
            ViewData["RoomName"] = GetRoomNamesList();
            int count = 0;
            if (ModelState.IsValid)
            {
                count = dao.InsertBooking(booking);
                if (count == 1)
                { 
                    ViewData["message"] = "Record inserted successfully";
                }
                else
                {
                    ViewData["message"] = dao.message;
                }
                return View("Index");

            }
            else return View("AddCourse", booking);
        }

        //means of checking the validity of a credit card number using LINQ
        //Resourcehttps://bitlush.com/blog/luhn-validation-for-asp-net-web-forms-and-mvc       
        public static bool IsCardValid(string cardNumber, bool allowSpaces = false)
        {
            if (allowSpaces)
            {
                cardNumber = cardNumber.Replace(" ", "");
            }
            if (cardNumber.Any(m=> !Char.IsDigit(m)))
            {
                return false;
            }
            int checksum = cardNumber.Select((m, i) => (m - '0') << ((cardNumber.Length - i - 1) & 1)).Sum(n => n > 9 ? n - 9 : n);

            return (checksum % 10) == 0 && checksum > 0;
        }
    }
}

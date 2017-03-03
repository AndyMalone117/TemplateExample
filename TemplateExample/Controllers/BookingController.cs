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
            if (ModelState.IsValid && cardValidate(booking.CreditCardNumber.ToString()) == true)
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
        public ActionResult ShowAll()
        {

            List<Booking_Model> list = dao.ShowAllBookings();

            return View(list);
        }
        private static int[] userInput; 

        //clears the input of potential formatting errors
        //www.youtube.com/watch?v=lkq3ywfCQcI
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
                    foreach (var character in userInput[i].ToString())
                    {
                        sum += int.Parse(character.ToString());
                    }
                    continue;
                }
                sum += userInput[i];
            }
            return sum;
        }
        //The boolean method is called above 
        public static bool cardValidate(string input)
        {
            cleanInput(input);
            MultiplyValues();
            //calling method AddValues and setting the boolen to true if result = 0
            return AddValues() % 10 == 0;
        }
    }
}



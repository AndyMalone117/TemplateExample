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
        public ActionResult AddBooking()
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
        public ActionResult AddBooking(Booking_Model booking)
        {
            int count = 0;
            if (ModelState.IsValid)
            {
                count = dao.InsertBooking(booking);
                if (count == 1)
                    ViewData["message"] = "Record inserted";
                else
                    ViewData["message"] = dao.message;
                return View("Index");
            }
            else
                return View("AddBooking", booking);
        }
   
    }
}

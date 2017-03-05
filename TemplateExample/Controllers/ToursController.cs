using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BayviewHouse.Models;

namespace BayviewHouse.Controllers
{
    public class ToursController : Controller
    {
         DAO dao = new DAO();
        // GET: Tours
        public ActionResult Index()
        {
            ViewData["TourArea"] = GetTourTitles();
            return View();
        }
        private List<Tour_Model> GetTours()
        {
            dao = new DAO();

            List<Tour_Model> tours = dao.PopulateTours();
            return tours;
        }

        private List<string> GetTourTitles()
        {
            List<string> tourTitles = new List<string>();
            List<Tour_Model> tours = GetTours();
            foreach (Tour_Model c in tours)
            {
                tourTitles.Add(c.TourArea);
            }

            return tourTitles;
        }
        [HttpGet]
        public ActionResult CustomerTour()
        {

            return View();
        }


        [HttpPost]
        public ActionResult AddCustomerTour(CustomerTour_Model customerTour)
        { 
            ViewData["TourArea"] = GetTourTitles();
            dao = new DAO();
            int count = 0;
            if (ModelState.IsValid)
            {
                count = dao.InsertCustomerTour(customerTour);
                if (count == 1)
                {
                    TempData["Message"] = "Tour Booking Confirmed";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["message"] = dao.message;
                }
                return View("Index");

            }
            else return View("Index", customerTour);
        }


        public ActionResult ShowAll()
        {
            //List<Booking_Model> bookingList = new List<Booking_Model>();
            dao = new DAO();
            List<Tour_Model> toursList = dao.ShowAllTours();
            return View(toursList);
        }


        public ActionResult ShowAllToursBooked()
        {
            //List<Booking_Model> bookingList = new List<Booking_Model>();
            dao = new DAO();
            List<CustomerTour_Model> toursbookedList = dao.ShowAllBookedTours();
            return View(toursbookedList);
        }
    }


}
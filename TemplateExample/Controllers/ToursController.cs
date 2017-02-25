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
         DAO dao;
        // GET: Tours
        public ActionResult Index()
        {
            ViewData["TourArea"] = GetTourTitles();
            ViewData["PricePerPerson"] = GetTourPrices();
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
        private List<string> GetTourPrices()
        {
            List<string> tourPrices = new List<string>();
            List<Tour_Model> prices = GetTours();
            foreach (Tour_Model c in prices)
            {
                tourPrices.Add(c.PricePerPerson.ToString());
            }

            return tourPrices;
        }
    }
}
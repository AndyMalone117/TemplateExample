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
            List<string> courseTitles = new List<string>();
            List<Tour_Model> courses = GetTours();
            foreach (Tour_Model c in courses)
            {
                courseTitles.Add(c.TourArea);
            }

            return courseTitles;
        }
}
}
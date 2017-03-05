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
    public class RoomsController : Controller
    {
        DAO dao = new DAO();
        
        // GET: Rooms
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowAllRooms()
        {

            List<Room_Model> roomList = dao.ShowAllRooms();
            return View(roomList);
        }
    }
}
﻿using BayviewHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BayviewHouse.Controllers
{
    public class LoginController : Controller
    {

        DAO dao = new DAO();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Status()
        {
            return View();
        }

      

        public ActionResult Logout()
        {
            Session.Clear();
            return View("../Home/Index");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {

            if (ModelState.IsValid)
            {

                if (model.UserRole == Role.Staff && model.Email == "staff@gmail.com" && model.Password == "BayStaff")
                {
                    Session["Name"] = "Staff";
                    return RedirectToAction("Index", "Staff");
                }

                if (model.UserRole == Role.Staff && model.Email == "mgmt@gmail.com" && model.Password == "BayMgmt")
                {
                    Session["Name"] = "Management";
                    return RedirectToAction("Index", "Staff");
                }


                if (Session["Name"] != null)
                    return View("../Home/Index");

                else
                {
                    ViewData["Error"] = "Error: " + dao.message;
                    return View("Error");
                }

            }
            else
            {

                return View("Index", model);
            }
        }
    }

}
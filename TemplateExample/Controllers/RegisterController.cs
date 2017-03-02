using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BayviewHouse.Models;
using System.Web.Helpers;

namespace BayviewHouse.Controllers
{
    public class RegisterController : Controller
    {
        DAO dao = new DAO();
        // GET: RegisterLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Customer_Model customer)
        {
            int count;
            
            //  member = new Member();
            if (ModelState.IsValid)
            {
                if (customer.Password != customer.PasswordConfirm)
                {
                    ViewData["status"] = "Password Enter Does not Match";
                }
                else
                {
                    count = dao.InsertCustomer(customer);
                    if (count > 0)
                        ViewData["status"] = "Registration Successfull";
                    else
                        ViewData["status"] = "Error: " + dao.message;
                }
                return View("status");
            }
            else return View("Index", customer);
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            string password = form["Password"];
            string match = form["txtMatch"];

            //Encrypting the passwrod and obtaianing the hash value
            string hashed = Crypto.HashPassword(password);

            ViewData["hashed"] = hashed;
            //matching the encrypted password with the newly entered match
            if (Crypto.VerifyHashedPassword(hashed, match))
            {
                return Content("Success");
            }
            return View("Hashed");
        }
    }
}
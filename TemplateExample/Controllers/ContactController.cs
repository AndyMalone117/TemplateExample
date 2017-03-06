using BayviewHouse.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace BayviewHouse.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
       
        static DataSet ds;
        static DataTable dt;
        static DateTime td;
        

        // GET: ContactUs
        public ActionResult Index()
        {
            if (System.IO.File.Exists(Server.MapPath(@"~/feedback.xml")))
            {
                td = DateTime.Now;
                ds = new DataSet();

                ds.ReadXml(Server.MapPath(@"~/feedback.xml"));

                dt = ds.Tables["customer_comment"];

            }
            else
            {
                ds = new DataSet("customer_comments");
                dt = new DataTable("customer_comment");
                dt.Columns.Add("name");
                dt.Columns.Add("email");
                dt.Columns.Add("bookingRef");
                dt.Columns.Add("topic");
                dt.Columns.Add("comments");
                dt.Columns.Add("stayAgain");
                dt.Columns.Add("recommend");
                dt.Columns.Add("date");
                ds.Tables.Add(dt);

            }

            return View();
        }

        public ActionResult Contact (ContactModel model)
        {
            if (ModelState.IsValid)
            {
                DataRow row = dt.NewRow();
                if (model.Name == "" || model.Name == null)
                    row["name"] = "";
                else
                    row["name"] = model.Name;
                    row["email"] = model.Email;
                    row["bookingRef"] = model.BookingRef;
                    row["topic"] = model.Topic;
                    row["comments"] = model.Comments;
                    row["stayAgain"] = model.Stay;
                    row["recommend"] = model.Recommend;
                    row["date"] = model.Time.ToLongDateString();
                

                dt.Rows.Add(row);
                ds.WriteXml(Server.MapPath(@"~/feedback.xml"));

                return View("Comments");
            }
            else return View("Index", model);
        }

        public ActionResult Feedback()
        {
            List<ContactModel> list = new List<ContactModel>();
            if (System.IO.File.Exists(Server.MapPath(@"~/feedback.xml")))
            {
                DataSet dSet = new System.Data.DataSet();
                dSet.ReadXml(Server.MapPath(@"~/feedback.xml"));

                DataTable comments = dSet.Tables["customer_comment"];
                foreach (DataRow row in comments.Rows)
                {
                    ContactModel model = new ContactModel();
                    model.Name = row["name"].ToString();
                    model.Email = row["email"].ToString();
                    model.BookingRef = row["bookingRef"].ToString();
                    model.Topic = row["topic"].ToString();
                    model.Comments = row["comments"].ToString();
                    model.Stay = row["stayAgain"].ToString();
                    model.Recommend = row["recommend"].ToString();
                    //string istring = row["date"].ToString();
                    //model.Time = DateTime.ParseExact(istring, "dd-mmM-yyyy HH:mm:ss tt", null);
                    //model.Time = DateTime.ParseExact(istring, "D", null);
                    
                    list.Add(model);


                }
            }
            return View(list);
        }

    }
}
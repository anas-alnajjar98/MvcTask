using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTask_7_24_2024_.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Login(string email, string password)
        {
            string[] cred = { "anasalnjar234@gmail.com", "123456789" };
            if (email == cred[0] && password == cred[1])
            {
                Session["Is_login"] = true;
                Session["username"] = email;
                return RedirectToAction("Index");
            }
            else
            {
                Session["Is_login"] = false;
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["Is_login"] = false;
            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Your Login page.";
            return View();
        }

        private static List<Dictionary<string, string>> contactUsList = new List<Dictionary<string, string>>();

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.ContactUsList = contactUsList;
            return View();
        }

        [HttpPost]
        public ActionResult Contact(string name, string email, string message)
        {
            var formData = new Dictionary<string, string>
            {
                { "Name", name },
                { "Email", email },
                { "Message", message }
            };

            contactUsList.Add(formData);

            ViewBag.ContactUsList = contactUsList;
            return View();
        }
    }
}
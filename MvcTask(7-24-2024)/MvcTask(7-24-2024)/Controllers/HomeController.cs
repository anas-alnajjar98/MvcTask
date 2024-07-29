using MvcTask_7_24_2024_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static MvcTask_7_24_2024_.Controllers.USERSController;

namespace MvcTask_7_24_2024_.Controllers
{
    public class HomeController : Controller
    {
        private USERSEntities1 DB = new USERSEntities1();
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
            var user = DB.USERINFOes.Where(x => x.email == email && x.password == password).FirstOrDefault();
            if (user == null)
            {
                Session["Is_login"] = false;
                ViewBag.LoginErrorMessage = "Wrong Username or Password";
                return View("Login");
            }

            // Set session variables
            Session["Is_login"] = true;
            Session["username"] = email;
            Session["password"] = password;

            
            HttpCookie cookie = new HttpCookie("UserInfo");
            cookie.Values["ID"] = user.ID.ToString();
            cookie.Values["Name"] = user.name;
            cookie.Values["Email"] = user.email;
            cookie.Values["Password"] = user.password;
            cookie.Values["Image"] = user.image;
            cookie.Expires = DateTime.Now.AddHours(1); 
            Response.Cookies.Add(cookie);

            return RedirectToAction("Profile");
            
        
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
        public ActionResult Profile() {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            if (cookie != null)
            {
                ViewBag.ID = cookie.Values["ID"];
                ViewBag.UserName = cookie.Values["Name"];
                ViewBag.UserEmail = cookie.Values["Email"];
                ViewBag.UserImage = cookie.Values["Image"];
            }
            

            return View();
        }
    }
}
using MvcTask_7_24_2024_.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MvcTask_7_24_2024_.Controllers
{
    public class USERSController : Controller
    {
        // GET: USERS
        public class UserModel
        {
            public string name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
        }
        private USERSEntities1 DB = new USERSEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERINFO userinfo = DB.USERINFOes.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();

            }
            return View(userinfo);
        }
        public ActionResult Create() { return View(); }
        public ActionResult Create([Bind(Include = "name, email,password")] USERINFO userinfo, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                DB.USERINFOes.Add(userinfo);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Register(UserModel model, [Bind(Include = "name, email,password")] USERINFO userinfo)
        {
            if (ModelState.IsValid)
            {
                if (model.Password == model.ConfirmPassword)
                {
                    DB.USERINFOes.Add(userinfo);
                    DB.SaveChanges();
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    ModelState.AddModelError("ConfirmPassword", "Passwords do not match.");
                }
            }

            return View(model);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTask_7_23_2024_.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult FormRegs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FormContent(FormCollection form) {
            ViewBag.name = form["name"];
            ViewBag.num = form["num"];
            ViewBag.gender = form["gender"];
            ViewBag.Cont = form["Cont"];
            ViewBag.inter = form["inter"];
            return View();
        }
    }
}
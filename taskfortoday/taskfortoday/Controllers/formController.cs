using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace taskfortoday.Controllers
{
    public class Item
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
    }

    public class FormController : Controller
    {
        // GET: Form
        public ActionResult Index()
        { 
            var items = Session["ProductInfo"] as List<Item> ?? new List<Item>();
            return View(items);
        }

        public ActionResult CreateForm() {
        return View();
        }
        [HttpPost]
        public ActionResult CreateForm(string name, string price, string image)
        {
            
            var items = Session["ProductInfo"] as List<Item> ?? new List<Item>();

            
            items.Add(new Item { Name = name, Price = price, Image = image });

           
            Session["ProductInfo"] = items;

           
            return RedirectToAction("Index");
        }
    }
}

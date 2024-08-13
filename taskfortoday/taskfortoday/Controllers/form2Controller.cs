using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace taskfortoday.Controllers
{
    public class form2Controller : Controller
    {
        // GET: form2
        public ActionResult Index()
        {
            List<Dictionary<string, string>> products = Session["Products"] as List<Dictionary<string, string>>;

            if (products == null)
            {
                products = (List<Dictionary<string, string>>)Session["Products"];
            }

            return View(products);
        }

        [HttpPost]

        public ActionResult CreateForm(string productName, string productPrice, string productImage) {
            List<Dictionary<string, string>> products = Session["Products"] as List<Dictionary<string, string>>;

            if (products == null)
            {
                products = new List<Dictionary<string, string>>();
            }


            Dictionary<string, string> product = new Dictionary<string, string>
            {
                {"Name",productName},
                {"Price", productPrice},
                {"Image",productImage}
            };

            products.Add(product);
            Session["Products"] = products;

            return View();

        }
    }
}
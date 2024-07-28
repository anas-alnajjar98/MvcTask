using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcTASK_7_28_2024_.Models;

namespace MvcTASK_7_28_2024_.Controllers
{
    public class IPHONEController : Controller
    {
        private IPHONEEntities DB = new IPHONEEntities();

        // GET: IPHONE
        public ActionResult Index()
        {
            return View(DB.IPHONEINFOes.ToList());
        }

        // GET: IPHONE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IPHONEINFO iphone = DB.IPHONEINFOes.Find(id);
            if (iphone == null)
            {
                return HttpNotFound();
            }
            return View(iphone);
        }

        // GET: IPHONE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IPHONE/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NAME,PRICE,IMAGE")] IPHONEINFO iphone, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(ImageFile.FileName);
                    string path = Path.Combine(Server.MapPath("~/img"), fileName);
                    ImageFile.SaveAs(path);
                    iphone.IMAGE = "~/img/" + fileName;
                }

                DB.IPHONEINFOes.Add(iphone);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iphone);
        }

        // GET: IPHONE/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IPHONEINFO iphone = DB.IPHONEINFOes.Find(id);
            if (iphone == null)
            {
                return HttpNotFound();
            }
            return View(iphone);
        }

        // POST: IPHONE/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME,PRICE,IMAGE")] IPHONEINFO iphone, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(ImageFile.FileName);
                    string path = Path.Combine(Server.MapPath("~/img"), fileName);
                    ImageFile.SaveAs(path);
                    iphone.IMAGE = "~/img/" + fileName;
                }

                DB.Entry(iphone).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iphone);
        }

        // GET: IPHONE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IPHONEINFO iphone = DB.IPHONEINFOes.Find(id);
            if (iphone == null)
            {
                return HttpNotFound();
            }
            return View(iphone);
        }

        // POST: IPHONE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IPHONEINFO iphone = DB.IPHONEINFOes.Find(id);
            DB.IPHONEINFOes.Remove(iphone);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DB.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

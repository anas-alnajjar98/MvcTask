using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcTask_7_25_2024_.Models;

namespace MvcTask_7_25_2024_.Controllers
{
    public class productsInfoesController : Controller
    {
        private PRODUCTSEntities db = new PRODUCTSEntities();

        // GET: productsInfoes
        public ActionResult Index()
        {
            

            return View(db.productsInfoes.ToList());
        }

        // GET: productsInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productsInfo productsInfo = db.productsInfoes.Find(id);
            if (productsInfo == null)
            {
                return HttpNotFound();
            }
            return View(productsInfo);
        }

        // GET: productsInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: productsInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME,PRICE,IMAGE")] productsInfo productsInfo)
        {
            if (ModelState.IsValid)
            {
                db.productsInfoes.Add(productsInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productsInfo);
        }

        // GET: productsInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productsInfo productsInfo = db.productsInfoes.Find(id);
            if (productsInfo == null)
            {
                return HttpNotFound();
            }
            return View(productsInfo);
        }

        // POST: productsInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME,PRICE,IMAGE")] productsInfo productsInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productsInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productsInfo);
        }

        // GET: productsInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productsInfo productsInfo = db.productsInfoes.Find(id);
            if (productsInfo == null)
            {
                return HttpNotFound();
            }
            return View(productsInfo);
        }

        // POST: productsInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productsInfo productsInfo = db.productsInfoes.Find(id);
            db.productsInfoes.Remove(productsInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

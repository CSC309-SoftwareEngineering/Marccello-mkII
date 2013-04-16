using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marccello.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseFirstContext db = new DatabaseFirstContext();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(db.majors.ToList());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(string id = null)
        {
            major major = db.majors.Find(id);
            if (major == null)
            {
                return HttpNotFound();
            }
            return View(major);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(major major)
        {
            if (ModelState.IsValid)
            {
                db.majors.Add(major);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(major);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(string id = null)
        {
            major major = db.majors.Find(id);
            if (major == null)
            {
                return HttpNotFound();
            }
            return View(major);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(major major)
        {
            if (ModelState.IsValid)
            {
                db.Entry(major).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(major);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(string id = null)
        {
            major major = db.majors.Find(id);
            if (major == null)
            {
                return HttpNotFound();
            }
            return View(major);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            major major = db.majors.Find(id);
            db.majors.Remove(major);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
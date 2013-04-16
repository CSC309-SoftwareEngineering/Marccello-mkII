using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marccello.Controllers
{
    public class CourseController : Controller
    {
        private DatabaseFirstContext db = new DatabaseFirstContext();

        //
        // GET: /Course/

        public ActionResult Index(FormCollection collection)
        {
            
            var courses = db.courses.Include(c => c.major);
            return View(courses.ToList());
        }

        //
        // GET: /Course/Details/5

        public ActionResult Details(string id = null)
        {
            course course = db.courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        //
        // GET: /Course/Create

        public ActionResult Create()
        {
            ViewBag.department = new SelectList(db.majors, "department", "name");
            return View();
        }

        //
        // POST: /Course/Create

        [HttpPost]
        public ActionResult Create(course course)
        {
            if (ModelState.IsValid)
            {
                db.courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.department = new SelectList(db.majors, "department", "name", course.department);
            return View(course);
        }

        //
        // GET: /Course/Edit/5

        public ActionResult Edit(string id = null)
        {
            course course = db.courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.department = new SelectList(db.majors, "department", "name", course.department);
            return View(course);
        }

        //
        // POST: /Course/Edit/5

        [HttpPost]
        public ActionResult Edit(course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.department = new SelectList(db.majors, "department", "name", course.department);
            return View(course);
        }

        //
        // GET: /Course/Delete/5

        public ActionResult Delete(string id = null)
        {
            course course = db.courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        //
        // POST: /Course/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            course course = db.courses.Find(id);
            db.courses.Remove(course);
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
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
        private marccelloEntities2 db = new marccelloEntities2();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(db.Majors.ToList());
        }

        [HttpPost]
        public ActionResult Courses(int majorID)
        {
            List<MajorCourse> matchedCourses = (from vc in db.MajorCourses
                                                where vc.major_id == majorID
                                                select vc).ToList();

            List<Course> validCourseObjects = (from c in db.Courses.ToList()
                                               join mc in matchedCourses on c.course_id equals mc.course_id
                                               select c).ToList();

            return View(validCourseObjects);
        }
        //
        // GET: /Home/Details/5

        public ActionResult Details(string id = null)
        {
            Major major = db.Majors.Find(id);
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
        public ActionResult Create(Major major)
        {
            if (ModelState.IsValid)
            {
                db.Majors.Add(major);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(major);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(string id = null)
        {
            Major major = db.Majors.Find(id);
            if (major == null)
            {
                return HttpNotFound();
            }
            return View(major);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(Major major)
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
            Major major = db.Majors.Find(id);
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
            Major major = db.Majors.Find(id);
            db.Majors.Remove(major);
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
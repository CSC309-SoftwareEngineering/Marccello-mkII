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
        private marccelloEntities4 db = new marccelloEntities4();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(db.Majors.ToList());
        }

        [HttpPost]
        public ActionResult Courses(int majorID)
        {
            List<Course> validCourseObjects = (from c in db.Courses
                                               from mc in db.MajorCourses
                                               where mc.major_id == majorID
                                               && c.course_id == mc.course_id
                                               select c).ToList();

            List<Semester> Semesters = db.Semesters.ToList();
            ViewBag.Semesters = Semesters;

            return View(validCourseObjects);
        }

        [HttpPost]
        public ActionResult Semesters (List<int> courses, int semester)
        {
            // Retreive the Courses selected
            List<Course> SelectedCourses = new List<Course> ();
            if ( courses != null )
            {
                var list_of_courses = db.Courses.ToList();
                SelectedCourses = list_of_courses.Where(c => courses.Contains(c.course_id)).ToList();

                // Retreive the Semester That Selected
                Semester SelectedSemester = new Semester();
                var list_of_Semesters = (from s in db.Semesters
                                         where s.semester_id == semester
                                         select s).ToList();
                SelectedSemester = list_of_Semesters.First();
                ViewBag.SelectedSemester = SelectedSemester;


                foreach (var course in SelectedCourses)
                {
                    SemesterCourse sc = new SemesterCourse();
                    sc.course_id = course.course_id;
                    sc.semester_id = semester;

                    db.SemesterCourses.Add(sc);
                }
                db.SaveChanges();
            }

            return View(SelectedCourses);

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DurhamUniversity.Controllers
{
    public class HomeController : Controller
    {
        private DurhamUniEfContainer db = new DurhamUniEfContainer();

        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult Filter()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Title");
            var courses = db.Courses.ToList();
            return PartialView(courses);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Filter(int CourseId = 0)
        {
            Course course = db.Courses.Find(CourseId);
            return View(course);
        }
    }
}

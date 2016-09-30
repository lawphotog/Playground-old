using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DurhamUniversity.ViewModels;

namespace DurhamUniversity.Controllers
{
    public class CourseController : Controller
    {
        private DurhamUniEfContainer db = new DurhamUniEfContainer();

        //
        // GET: /Course/

        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        //
        // GET: /Course/Details/5

        public ActionResult Details(int id = 0)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        //
        // GET: /Course/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Course/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        //
        // GET: /Course/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            Course course = db.Courses
                .Include(c => c.Modules)
                .Where(c => c.Id == id)
                .Single();

            PopulateAssignedModuleData(course);
            return View(course);
        }

        private void PopulateAssignedModuleData(Course course)
        {
            var allModules = db.Modules;
            var courseModules = new HashSet<int>(course.Modules.Select(m => m.Id));
            var viewModel = new List<AssignedModuleData>();
            foreach (var module in allModules)
            {
                viewModel.Add(new AssignedModuleData
                {
                    ModuleID = module.Id,
                    Title = module.Name,
                    Assigned = courseModules.Contains(module.Id)
                });
            }
            ViewBag.Modules = viewModel;
        }

        //
        // POST: /Course/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(int id, FormCollection formCollection, string[] selectedModules)
        {
            var courseToUpdate = db.Courses
                                   .Include(i => i.Modules)
                                   .Where(i => i.Id == id)
                                   .Single();

            if (TryUpdateModel(courseToUpdate, "",
               new string[] { "Title"}))
            {
                try
                {
                    UpdateCourseModules(selectedModules, courseToUpdate);

                    db.Entry(courseToUpdate).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            PopulateAssignedModuleData(courseToUpdate);
            return View(courseToUpdate);
        }

        private void UpdateCourseModules(string[] selectedCourses, Course courseToUpdate)
        {
            if (selectedCourses == null)
            {
                courseToUpdate.Modules = new List<Module>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var instructorCourses = new HashSet<int>
                (courseToUpdate.Modules.Select(c => c.Id));
            foreach (var module in db.Modules)
            {
                if (selectedCoursesHS.Contains(module.Id.ToString()))
                {
                    if (!instructorCourses.Contains(module.Id))
                    {
                        courseToUpdate.Modules.Add(module);
                    }
                }
                else
                {
                    if (instructorCourses.Contains(module.Id))
                    {
                        courseToUpdate.Modules.Remove(module);
                    }
                }
            }
        }

        //
        // GET: /Course/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
                                
            return View(course);            
        }

        //
        // POST: /Course/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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
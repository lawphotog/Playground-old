using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DurhamUniversity.Controllers
{
    public class ModuleController : Controller
    {
        private DurhamUniEfContainer db = new DurhamUniEfContainer();

        //
        // GET: /Module/

        public ActionResult Index()
        {
            return View(db.Modules.ToList());
        }

        //
        // GET: /Module/Details/5

        public ActionResult Details(int id = 0)
        {
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        //
        // GET: /Module/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Module/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Module module)
        {
            if (ModelState.IsValid)
            {
                db.Modules.Add(module);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(module);
        }

        //
        // GET: /Module/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        //
        // POST: /Module/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(Module module)
        {
            if (ModelState.IsValid)
            {
                db.Entry(module).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(module);
        }

        //
        // GET: /Module/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        //
        // POST: /Module/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Module module = db.Modules.Find(id);
            db.Modules.Remove(module);
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
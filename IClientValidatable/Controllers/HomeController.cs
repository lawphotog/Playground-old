using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Customer customer)
        {
            if(ModelState.IsValid)
            {
                //add customer
            }

            return View();
        }

        public ActionResult About()
        {
            var model = new MyViewModel
            {
                AssignedDate = DateTime.Now.AddDays(2)
            };

            return View(model);
        }

         [HttpPost]
        public ActionResult About(MyViewModel model)
        {
            if(ModelState.IsValid)
            {

            }

            return View(model);
        }

        public ActionResult Contact()
        {
            return View(new FoobarVm());
        }

        [HttpPost]
        public ActionResult Contact(FoobarVm model)
        {
            if(ModelState.IsValid)
            {

            }

            return View(model);
        }

        public ActionResult BarMustBeBar(string str)
        {
            if(str == "bar")
                return Json(true, JsonRequestBehavior.AllowGet);

            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}
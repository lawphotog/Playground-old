using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cookie.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var saveName = HttpContext.Request.Cookies["saveName"];
            if (saveName != null)
            {
                ViewBag.saveName = saveName.Value;
            }
            return View();
        }

        [HttpPost]
        public ActionResult SaveName(string userName)
        {
            if (userName != string.Empty)
            {
                HttpCookie myCookie = new HttpCookie("saveName", userName);
                HttpContext.Response.Cookies.Add(myCookie);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete()
        {
            HttpCookie myCookie = new HttpCookie("saveName");
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PretendingWebForm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult Robots()
        {
            //IIS handles .txt as static file. See web.config to exclude .txt from static file

            var text = "User-agent: * Disallow: /";
            return Content(text, "text/plain", Encoding.UTF8);
        }
    }
}
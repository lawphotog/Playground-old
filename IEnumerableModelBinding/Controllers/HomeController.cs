using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IEnumerableModelBinding.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var list = new List<Book>
            {
                new Book { Name = "HTML5", Quantity = 0 },
                new Book { Name = "OOP", Quantity = 0 },
                new Book { Name = "MVC", Quantity = 0 },
            };
            return View(list);
        }

        [HttpPost]
        public ActionResult Index(List<Book> books)
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
    }
}
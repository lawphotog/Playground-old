using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCwithMEF.Controllers
{
    public class HomeController : Controller
    {
        [Import]
        private ILogger _logger;

        public ActionResult Index()
        {
            _logger.Log("Home-Index");
            return View();
        }

        
    }
}
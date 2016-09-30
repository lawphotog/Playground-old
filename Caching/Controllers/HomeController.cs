using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;

namespace Caching.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ObjectCache cache = MemoryCache.Default;
            string fileContents = cache["filecontents"] as string;

            if (fileContents == null)
            {
                CacheItemPolicy policy = new CacheItemPolicy();

                List<string> filePaths = new List<string>();
                filePaths.Add("C:\\Temp\\example.txt");

                policy.ChangeMonitors.Add(new
                HostFileChangeMonitor(filePaths));

                // Fetch the file contents.
                fileContents =
                    System.IO.File.ReadAllText("C:\\Temp\\example.txt");

                cache.Set("filecontents", fileContents, policy);
            }                       

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
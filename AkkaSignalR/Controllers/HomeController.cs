using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AkkaSignalR.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReadFiles()
        {
            var memoryfiles = new List<string>();

            var path = "C:\\Temp\\LoadComplete";
            var files = Directory.GetFiles(path, "*.xml", SearchOption.AllDirectories);

            //var count = files.Length;

            foreach(string file in files)
            {
                memoryfiles.Add(file);
            }

            return View();
        }

        public ActionResult About()
        {
            int count = 0;
            var memoryfiles = new List<string>();

            var path = "C:\\Temp\\LoadComplete";
            var files = Directory.EnumerateFiles(path, "*.xml", SearchOption.AllDirectories);

            //var count = files.Count();

            foreach (string file in files)
            {
                memoryfiles.Add(file);
                count++;
                Debug.Write(count);
            }

            return View();
        }

        public ActionResult Contact()
        {
            var memoryfiles = new List<string>();
            var path = "C:\\Temp\\LoadComplete";

            foreach (string file in GetFiles(path))
            {
                memoryfiles.Add(file);
            }

            return View();
        }

        static IEnumerable<string> GetFiles(string path)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(path);
            while (queue.Count > 0)
            {
                path = queue.Dequeue();
                try
                {
                    foreach (string subDir in Directory.GetDirectories(path))
                    {
                        queue.Enqueue(subDir);
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
                string[] files = null;
                try
                {
                    files = Directory.GetFiles(path);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
                if (files != null)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        yield return files[i];
                    }
                }
            }
        }
    }
}
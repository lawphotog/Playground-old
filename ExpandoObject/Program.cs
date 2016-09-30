using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Example 1 ExpandoObject
            Console.WriteLine("Example 1");
            dynamic expando = new System.Dynamic.ExpandoObject();
            expando.Name = "Scott";
            expando.Speak = new Action(() => Console.WriteLine(expando.Name));

            //expando.Speak();

            foreach(var member in expando)
            {
                Console.WriteLine(member.Key);
            }

            //Console.Read();
            Console.WriteLine("---------------");

            //----------------------------------------------
            //Example 2 Read file from XML
            Console.WriteLine("Example 2");
            var str = AppDomain.CurrentDomain.BaseDirectory;
            var path = System.IO.Path.Combine(str, "XMLFile1.xml");
            var doc = XDocument.Load(path);

            foreach(var element in doc.Element("Employees")
                .Elements("Employee"))
            {
                Console.WriteLine(element.Element("FirstName").Value);
            }

            Console.WriteLine("---------------");

            //Example 3 Expando custom extension method
            Console.WriteLine("Example 3");
            
            var doc2 = XDocument.Load(path).AsExpando();

            foreach(var employee in doc2.Employees)
            {
                Console.WriteLine(employee.FirstName);
            }

            //Console.Read();
            Console.WriteLine("---------------");

            //Example 4 date time combine function
            Console.WriteLine("Example 4");

            DateTime date = DateTime.Parse("1/5/2005");
            DateTime time = DateTime.Parse("1/1/0001 9:55pm");

            DateTime combined = Combine(date, time);            

            Console.WriteLine(combined);

            Console.WriteLine("---------------");

            //Example 5 Extension method
            Console.WriteLine("Example 5");

            DateTime combined2 = date.Combine(time);
            Console.WriteLine(combined2);           


            Console.WriteLine("---------------");
            Console.Read();
        }

        private static DateTime Combine(DateTime date, DateTime time)
        {
            return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
        }
    }

    public static class Extensions
    {
        public static DateTime Combine(this DateTime date, DateTime time)
        {
            return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
        }        
    }
}

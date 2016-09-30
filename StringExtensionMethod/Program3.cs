using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExtensionMethod
{
    class Program3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tomorrow is " + DateTime.Now.Tomorrow().ToString("dd/MM/yyyy"));
            Console.WriteLine("The day after tomorrow is " + DateTime.Now.TheDayAfterTomorrowShortDate());
            Console.ReadLine();
        }
    }

    public static class DateTimeExtension
    {
        public static DateTime Tomorrow(this DateTime dateTime)
        {
            return DateTime.Now.AddDays(1);
        }

        public static string TheDayAfterTomorrowShortDate(this DateTime dateTime)
        {
            return DateTime.Now.AddDays(2).ToShortDateString();
        }
    }
    
}

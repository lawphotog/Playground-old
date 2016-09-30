using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = "Jonny";
            Console.WriteLine(user.Welcome());
            Console.ReadLine();
        }
    }

    public static class CustomerExtensions
    {
        public static string Welcome(this string user)
        {
            return "Welcome " + user;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExtensionMethod
{
    class Program2
    {
        static void Main(string[] args)
        {
            var customer = new Customer { Id = 1, Name = "John" };
            
            Console.WriteLine(customer.Welcome());
            customer.Register();
            Console.ReadLine();
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }     
   
        public void Register()
        {
            Console.WriteLine("Registered");
        }
    }

    public static class Extension
    {
        public static string Welcome(this Customer customer)
        {
            return "Welcome " + customer.Name;
        }
    }
}

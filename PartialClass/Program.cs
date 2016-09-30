using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Student();

            s.Id = 1;
            s.Name = "John";
            s.Dob = DateTime.Now;
            s.Address = "London";
        }
    }

    partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    partial class Student
    {
        public DateTime Dob { get; set; }
        public string Address { get; set; }
    }
}

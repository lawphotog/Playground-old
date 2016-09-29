using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferCompositionOverInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new InheritanceEmployee { Salary = 1000, Name = "John" };
            Console.WriteLine("InheritanceEmployee: " + employee.Name + " " + employee.Salary);

            var employee2 = new CompositionEmployee ( new Person { Name = "John" }, 1000 );            
            Console.WriteLine("CompositionEmployee: " + employee2.Person.Name + " " + employee2.Salary);

            Console.ReadLine();
        }
    }

}

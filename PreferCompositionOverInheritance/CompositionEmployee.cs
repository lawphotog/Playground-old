using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferCompositionOverInheritance
{
    public class CompositionEmployee
    {
        public int Salary { get; private set; }
        public Person Person { get; private set; }

        public CompositionEmployee(Person person, int salary)
        {
            this.Person = person;
            this.Salary = salary;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndComposition
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person(1, "Jonny");
            Employee jonny = new Employee(p, 5000);

            Person p2 = new Person(2, "Paul");
            Employee paul = new Employee(p, 10000);
            Manager paul_TheManager = new Manager(p2, paul);
        }
    }
    

    class Person
    {
        int Id;
        string Name;

        public Person(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }

    class Employee
    {
        public int Salary;
        private Person _person;

        public Employee(Person p, int salary)
        {
            this._person = p;
            this.Salary = salary;
        }
    }

    class Manager 
    {
        int Salary;
        public Manager(Person p, Employee e)
        {
            this.Salary = e.Salary;
        }
    }
}

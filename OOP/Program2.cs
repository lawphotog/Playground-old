using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Program2
    {
        static void Main(string[] args)
        {
            var breakfast = new Banana();
            breakfast.Eat();
            Console.ReadLine();
        }
    }

    public class Banana : RawEatable
    {

    }

    public interface IEatable
    {
        void Eat();
    }

    public class RawEatable : IEatable
    {
        public void Eat()
        {
            Console.WriteLine("Eating .. ");
        }
    }

}

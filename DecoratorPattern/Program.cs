using DecoratorPattern.Component;
using DecoratorPattern.ConcreateComponent;
using DecoratorPattern.ConcreateDecorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IceCream iceCream = new Vanilla();

            iceCream = new Fudge(iceCream);

            iceCream = new Sprinkle(iceCream);

            Console.WriteLine(iceCream.Cost());

            Console.ReadLine();
        }
    }
}

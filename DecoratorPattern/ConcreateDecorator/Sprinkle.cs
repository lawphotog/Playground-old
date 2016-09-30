using DecoratorPattern.Component;
using DecoratorPattern.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.ConcreateDecorator
{
    public class Sprinkle: Topping
    {
        public Sprinkle(IceCream s): base(s)
        {

        }

        public override double Cost()
        {
            return 0.50 + IceCream.Cost();
        }
    }
}

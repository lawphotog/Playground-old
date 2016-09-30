using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outer.Inner
{
    //if using System; is outside the namespace .. 
    //the compiler will look for Outer.Math class in Class2.cs where Math class doesn't have PI property
    using System;

    class Foo
    {
        static void Bar()
        {
            double d = Math.PI;
        }
    }
}

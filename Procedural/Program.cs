using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Square
    {        
        public double Side { get; set; }
    }

    public class Rectangle
    {
        public double Height { get; set; }
        public double Width { get; set; }
    }

    public class Circle
    {
        public int center { get; set; }
        public double radius { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var shape = new Square();
            shape.Side = 10;           
            Console.WriteLine(area(shape));

            Console.ReadLine();
        }

        public static double area(object shape)
        {
            var type = shape.GetType().Name;
            if (type == "Square")
            {
                Square s = (Square)shape;
                return s.Side * s.Side;
            }
            else if (type == "Rectangle")
            {
                Rectangle r = (Rectangle)shape;
                return r.Height * r.Width;
            }
            else if(type == "Circle")
            {
                var PI = 3.14159;
                Circle c = (Circle)shape;
                return c.center * c.radius * PI;
            }

            throw new Exception();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape square = new Square { Side = 10 };
            Console.WriteLine(square.Area());
            Console.ReadLine();
        }
    }

    public interface Shape
    {
        double Area();
    }

    public class Square : Shape
    {
        private int side;

        public int Side
        {
            get { return side; }
            set { side = value; }
        }        

        public double Area()
        {
            return side * side;
        }
    }
}

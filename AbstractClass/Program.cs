using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new BMW();       
            
            car.Drive();
            car.Stop();
            Console.ReadLine();
        }
    }

    abstract class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }

        //Child class must implement this method
        public abstract void Drive();        

        //Child class may or may not implement this method
        public virtual void Stop()
        {
            Console.WriteLine("stopped");
        }
    }

    class BMW : Car
    {
        public override void Drive()
        {
            Console.WriteLine("BMW driving ..");
        }

        public override void Stop()
        {
            Console.WriteLine("BMW stopped");
        }
    }

    //VB/C#
    //MustInherit = Abstract
    //Overridable = Virtual
    //Module = Static
}

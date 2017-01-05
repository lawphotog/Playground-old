using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceCasting
{
    class Program
    {
        static void Main(string[] args)
        {
            var honda = new Honda()
            {
                HondaSpecialFeature = "Honda drives fast"
            };

            var aCar = (Car)honda;

            if (aCar.GetType() == typeof(Honda))
            {
                var hondaCar = (Honda)aCar;

                Console.WriteLine("this car is a Honda");
                Console.WriteLine(hondaCar.HondaSpecialFeature);
            }

            Console.Read();
        }

        class Car
        {
            public Car()
            {
                Name = "Honda";
            }

            public Car(string model) : this()
            {
                Model = model;
            }

            public string Id { get; set; }
            public string Name { get; set; }
            public string Model { get; set; }

        }

        class Honda : Car
        {
            public string HondaSpecialFeature { get; set; }
        }
    }
}

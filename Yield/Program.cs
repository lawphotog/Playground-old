using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yield
{
    class Program
    {
        static void Main(string[] args)
        {

            

            var list1 = new List<Fruit> { new Fruit { Id = 1, Name = "Apple" }, new Fruit { Id = 2, Name = "Orange" } };
            var list2 = new List<Fruit> { new Fruit { Id = 3, Name = "Pear" }, new Fruit { Id = 4, Name = "Strewberry" } };

            var prog = new Program();
            var names = prog.EfficientMerge(list1, list2);

            foreach (var o in names)
            {
                Console.WriteLine(o.Name);
            }
        
            Console.ReadLine();
        }

        public IEnumerable<Fruit> EfficientMerge(List<Fruit> list1, List<Fruit> list2)
        {
            foreach (var o in list1)
                yield return o;
            foreach (var o in list2)
                yield return o;
        }

        public class Fruit
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}

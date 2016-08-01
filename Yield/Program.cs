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
            var list1 = new List<object> { new object[1], new object[2] };
            var list2 = new List<object> { new object[3], new object[4] };

            var prog = new Program();
            var name = prog.EfficientMerge(list1, list2);

            foreach (var o in name)
            {
                Console.WriteLine(o.GetType());
            }

            Console.ReadLine();
        }

        public IEnumerable<object> EfficientMerge(List<object> list1, List<object> list2)
        {
            foreach (var o in list1)
                yield return o;
            foreach (var o in list2)
                yield return o;
        }

        //rubbish
    }
}

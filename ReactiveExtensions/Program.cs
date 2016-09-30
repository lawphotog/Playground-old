using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;

namespace ReactiveExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = from number in Enumerable.Range(1, 5) select number;

            foreach (var number in query)
            {
                Console.WriteLine(number);
            }
            //Console.ReadLine();

            var obserableQuery = query.ToObservable();
            obserableQuery.Subscribe(Console.WriteLine);

            Console.ReadLine();
        }
    }
}

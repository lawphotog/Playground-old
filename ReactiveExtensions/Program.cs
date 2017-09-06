using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReactiveExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = from number in Enumerable.Range(1, 5000) select number;

            var obserableQuery = query.ToObservable();
            obserableQuery.Subscribe(Console.WriteLine);

            Console.ReadLine();
        }
    }
}

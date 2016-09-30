using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            var strategy = new ConcreateStrategyA();
            strategy.AlgorithemInterface();
            Console.ReadLine();
        }
    }

    abstract class Strategy
    {
        public abstract void AlgorithemInterface();
    }

    class ConcreateStrategyA: Strategy
    {
        public override void AlgorithemInterface()
        {
            Console.WriteLine("called ConcreateStrategyA.AlgorithemInterface()");
        }
    }

    class ConcreateStrategyB: Strategy
    {
        public override void AlgorithemInterface()
        {
            Console.WriteLine("called ConcreateStrategyB.AlgorithemInterface()");
        }
    }
}

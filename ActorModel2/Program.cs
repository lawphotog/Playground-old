using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka;
using Akka.Actor;

namespace ActorModel2
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("MySystem");

            var greeter = system.ActorOf<GreetingActor>("greeter");

            Console.WriteLine("Hello World 1");

            greeter.Tell(new Greet("Hello World 2"));
            greeter.Tell(new Greet("Hello World 3"));
            greeter.Tell(new Greet("Hello World 4"));

            Console.WriteLine("Hello World 5");

            Console.ReadLine();
        }
    }

    public class Greet
    {
        public Greet(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }

    public class GreetingActor : ReceiveActor
    {
        public GreetingActor()
        {

            Receive<Greet>(greet =>
                Print(greet.Message)
            );
        }

        void Print(string message)
        {
            Random rnd = new Random();
            int milliseconds = rnd.Next(1000, 5000);

            System.Threading.Thread.Sleep(milliseconds);
            Console.WriteLine(message);
        }
    }
}

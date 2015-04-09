using System;
using Akka.Actor;

namespace AkkanetConsoleApp
{
    public class Greet
    {
        public string Who { get; private set; }

        public Greet(string who)
        {
            Who = who;
        }
    }

    public class GreetingActor : ReceiveActor
    {
        public GreetingActor()
        {
            Receive<Greet>(greet => Console.WriteLine("Hello {0}", greet.Who));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("MySystem");

            var greeter = system.ActorOf<GreetingActor>("greeter");
            greeter.Tell(new Greet("World"));

            Console.ReadLine();
        }
    }
}

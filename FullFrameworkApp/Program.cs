using System;
using Akka.Actor;
using Common;

namespace FullFrameworkApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Full framework Akka.NET app.");

            var actorSys = ActorSystem.Create("TestActorSystem");
            var sft = actorSys.Serialization.FindSerializerForType(typeof(HiMessage));

            var props = Props.Create(() => new EchoActor());

            var actor = actorSys.ActorOf(props, "Echo");

            Console.ReadKey();
        }
    }
}

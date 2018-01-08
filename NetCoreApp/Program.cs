using System;
using System.Threading;
using Akka.Actor;

namespace NetCoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Core Akka.NET app.");

            var config = @"
                akka {
                    actor {
                        provider = remote
                    }
                    remote {
                        dot-netty.tcp {
                            port = 0
                            hostname = localhost
                        }
                    }
                }
            ";

            var actorSys = ActorSystem.Create("TestActorSystem", config);

            var testActorProps = Props.Create(() => new TestActor());

            var actor = actorSys.ActorOf(testActorProps, "Test");

            while (true)
            {
                actor.Tell("hiya");
                Thread.Sleep(1000);
            }
        }
    }
}

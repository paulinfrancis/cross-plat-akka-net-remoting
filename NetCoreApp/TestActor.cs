using System;
using System.Collections.Generic;
using Akka.Actor;
using Common;

namespace NetCoreApp
{
    public class TestActor : ReceiveActor
    {
        public TestActor()
        {
            Receive<string>(msg =>
            {
                var echoActorRef = Context.ActorSelection("akka.tcp://TestActorSystem@localhost:8888/user/Echo");
                echoActorRef.Tell(new HiMessage(msg, 1337, new List<string> { "core", "list" }));
            });

            Receive<HiMessage>(echo =>
            {
                Console.WriteLine($"{echo.Message}, {echo.Num}, {string.Join(" ", echo.ACollection)}");
            });
        }
    }
}

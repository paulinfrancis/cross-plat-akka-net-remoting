using System;
using System.Collections.Generic;
using Akka.Actor;
using Common;

namespace FullFrameworkApp
{
    public class EchoActor : ReceiveActor
    {
        public EchoActor()
        {
            Receive<HiMessage>(message =>
            {
                var sender = Sender;

                Console.WriteLine($"{message.Message}, {message.Num}, {string.Join(" ", message.ACollection)}");

                sender.Tell(new HiMessage($"Hi from TestActor on full framework, you said: {message.Message}.", 42, new List<string> { "full", "framework", "list" }));
            });
        }
    }
}

using common;
using System;
using System.IO;
using System.IO.Pipes;
using System.Text.Json;
using System.Threading;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client");

            Message message;

            using (var clientStream = new NamedPipeClientStream(".", "myPipe.Test", PipeDirection.InOut))
            {
                message = SimpleNamedPipeManager.ReceivedPoco<Message>(clientStream);
            }

            Console.WriteLine($"Received MessageId: {message.Id} --> {message.Content}");
        }
    }
}

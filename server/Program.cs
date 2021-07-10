using common;
using System;
using System.IO.Pipes;
using System.Text.Json;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server");

            Message message = new Message(1, "hello from the server!");

            using (var serverStream = new NamedPipeServerStream("myPipe.Test", PipeDirection.InOut))
            {
                SimpleNamedPipeManager.ServePOCO(serverStream, message);
            }

            Console.WriteLine("sent message");
        }
    }
}

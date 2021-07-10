using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Text.Json;
using System.Threading;

namespace common
{
    public static class SimpleNamedPipeManager
    {
        public static void ServePOCO<T>(NamedPipeServerStream serverStream,  T itemToSerialize)
        {
            serverStream.WaitForConnection();

            string jsonMessage = JsonSerializer.Serialize<T>(itemToSerialize);

            var bytes = System.Text.Encoding.UTF8.GetBytes(jsonMessage);

            serverStream.Write(bytes, 0, bytes.Length);

            serverStream.Disconnect();
        }

        public static T ReceivedPoco<T>(NamedPipeClientStream clientStream)
        {
            
            {
                clientStream.Connect(10000);
                int millisecCount = 0;

                while (!clientStream.CanRead)
                {
                    millisecCount = millisecCount + 500;
                    Thread.Sleep(500);
                }

                byte[] bytes;

                using (var stream = new MemoryStream())
                {
                    clientStream.CopyTo(stream);
                    bytes = stream.ToArray();
                }

                return JsonSerializer.Deserialize<T>(bytes);
            } 
        }
    }
}

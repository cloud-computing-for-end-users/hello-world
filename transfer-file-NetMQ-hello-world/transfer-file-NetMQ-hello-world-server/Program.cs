using NetMQ;
using NetMQ.Sockets;
using System;
using System.IO;

namespace transfer_file_NetMQ_hello_world_server
{
    class Program
    {
        private const string path = @"C:\Users\MSI\Desktop\";

        static void Main(string[] args)
        {
            using(var server = new ResponseSocket())
            {
                server.Bind("tcp://*:5555");
                Console.WriteLine("The application have initialised");

                var message = server.ReceiveMultipartMessage();
                var messagePartOne = message[0].ConvertToString();

                if ("FILE".Equals( messagePartOne ))
                {
                    var fileName = message[1].ConvertToString();
                    var data = message[2].ToByteArray();


                    Console.WriteLine("Frame 0:" + message[0].ConvertToString());
                    Console.WriteLine("Frame 1:" + fileName);
                    Console.WriteLine("Frame 2:" + data.Length);


                    var stream = File.OpenWrite(path + fileName);
                    stream.Write(data, 0, data.Length);
                    stream.Flush();
                    stream.Close();


                    Console.WriteLine("finished writing the file");
                    Console.ReadKey();
                }
            }
        }
    }
}

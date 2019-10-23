using NetMQ.Sockets;
using NetMQ;
using System;
using System.IO;

namespace transfer_file_NetMQ_hello_world
{
    class Program
    {
        private const string path = @"C:\Users\MSI\Desktop\bigFile.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Client initilizing");

            using (var client = new RequestSocket())
            {
                client.Connect("tcp://localhost:5555");

                byte[] data = File.ReadAllBytes(path);

                var f1 = "FILE";
                var f2 = "testFileToSend.txt";
                var f3 = data;


                client.SendMoreFrame(f1).SendMoreFrame(f2).SendFrame(f3);


                Console.WriteLine("Frame 1:" + f1);
                Console.WriteLine("Frame 2:" + f2);
                Console.WriteLine("Frame 3 - length:" + f3.Length);

                Console.WriteLine("finished sending file");


                Console.ReadKey();
            }
        }
    }
}

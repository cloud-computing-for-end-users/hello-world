using NetMQ;
using NetMQ.Sockets;
using System;

namespace net_mq_client
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tier 1");

            var sendSocket = new RequestSocket();
            sendSocket.Connect("tcp://127.0.0.1:" + net_mq_tier_two.Program.listeningPort);

            sendSocket.SendMoreFrame("MethidID").SendFrame("Frame 2: ma last frame");
            Console.WriteLine("finished sending");

            var response = sendSocket.ReceiveMultipartMessage();
            Console.WriteLine("Yaay I got a response: ");
            Console.WriteLine(response.Pop().ConvertToString());
            //Console.WriteLine(response.Pop().ConvertToString());
            Console.ReadKey();
        }
    }
}

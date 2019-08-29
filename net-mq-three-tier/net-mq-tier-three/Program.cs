using NetMQ;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;

namespace net_mq_tier_three
{
    public class Program
    {
        public static readonly string listeningPort = "61652";

        static void Main(string[] args)
        {
            Console.WriteLine("Tier 3 here");
            var reciveSocket = new ResponseSocket();
            reciveSocket.Bind("tcp://0.0.0.0:" + listeningPort);

            var multipartMessage = reciveSocket.ReceiveMultipartMessage();

            var frames = new List<NetMQFrame>();
            while(false == multipartMessage.IsEmpty)
            {
                frames.Add(multipartMessage.Pop());
            }

            Console.WriteLine(frames[3]);

            while(frames.Count > 2)
            {
                frames.RemoveAt(2);
            }

            frames.Add(new NetMQFrame("Yes this is from server three"));
            var responseMessage = new NetMQMessage(frames);
            reciveSocket.SendMultipartMessage(responseMessage);

            Console.ReadKey();
            
        }
    }
}

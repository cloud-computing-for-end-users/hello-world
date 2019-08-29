using NetMQ.Sockets;
using NetMQ;
using System;
using net_mq_tier_three;
using System.Collections.Generic;

namespace net_mq_tier_two
{
    public class Program
    {
        public const string listeningPort = "61653";

        static void Main(string[] args)
        {
            Console.WriteLine("Tier 2");

            var reciveSocket = new ResponseSocket();
            //reciveSocket.Bind("tcp://0.0.0.0:" + listeningPort);
            
            



            var newRouterSocket = new RouterSocket();
            newRouterSocket.Bind("tcp://0.0.0.0:" + listeningPort);

            Console.WriteLine("Ready to recive!");

            var message = newRouterSocket.ReceiveMultipartMessage();

            var sendSocket = new RequestSocket();
            sendSocket.Connect("tcp://127.0.0.1:" + net_mq_tier_three.Program.listeningPort);


            
            List<NetMQFrame> frames = new List<NetMQFrame>();
            while (false == message.IsEmpty)
            {
                var frame = message.Pop();
                frames.Add(frame);
            }

            if("MethidID" == frames[2].ConvertToString())
            {


                if (true) // debug
                {
                    foreach (var item in frames)
                    {
                        Console.WriteLine(item.ConvertToString());
                    }
                }

                var multiPartMessage = new NetMQMessage(frames);
                sendSocket.SendMultipartMessage(multiPartMessage);


                //now a response should be recived on the the same socket, and I need to figure out how to handle that.

                var responseMessage = sendSocket.ReceiveMultipartMessage();
                newRouterSocket.SendMultipartMessage(responseMessage);

                



            }
            else
            {
                //not a valid message
                Console.WriteLine("Something bad happened in tier 2");
            }



            //lets pretend I have validated where to send this message



            Console.ReadKey();
        }
    }
}

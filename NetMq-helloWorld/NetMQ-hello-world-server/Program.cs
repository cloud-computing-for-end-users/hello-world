using NetMQ;
using NetMQ.Sockets;
using System;
using System.Threading;

namespace NetMQ_hello_world_server
{
    class Program
    {
        const int ListeningPort = 55555;

        /// <summary>
        /// protocol for NetMq
        /// the <message> should be a string send as the second frame and the message must not contain more that two frames or it will be discarded by the server
        /// "A" as first frame if you want <message> + " hello" as response
        /// "B" as first frame if you want "hello " + <message>
        /// </summary>

        static void Main(string[] args)
        {
            Console.WriteLine("NetMQ server have started");


            var server = new ResponseSocket();

            server.Bind("tcp://*:" + ListeningPort);
            while (true)
            {
                var message = server.ReceiveMultipartMessage();
                if(message.FrameCount == 2)
                {
                    var frameOne = message[0];
                    Console.WriteLine("recived message with protocol code: " + frameOne.ConvertToString());
                    
                    //sending response
                    if (frameOne.ConvertToString() == "A") {
                        server.SendFrame(message[1].ConvertToString() + " hello");
                        continue;
                    }
                    else if(frameOne.ConvertToString() == "B"){
                        server.SendFrame(message[1].ConvertToString() + " hello");
                        continue;
                    }

                   
                }

                //must only occure if the message is not valid according to the protocol
                    server.SendFrame("INVALID FRAME COUNT!");
            }
        }
    }
}

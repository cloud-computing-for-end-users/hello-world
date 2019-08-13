using NetMQ;
using NetMQ.Sockets;
using System;

namespace NetMq_helloWorld
{
    class Program
    {

        /// <summary>
        /// protocol for NetMq
        /// the <message> should be a string send as the second frame and the message must not contain more that two frames or it will be discarded by the server
        /// "A" as first frame if you want <message> + "hello" as response
        /// "B" as first frame if you want "hello" + <message>
        /// </summary>

        const int portToConnectTo = 55555;

        static void Main(string[] args)
        {
            Console.WriteLine("NetMq hello wolrd client have started:");

            using(var client = new RequestSocket())
            {
                client.Connect("tcp://localhost:" + portToConnectTo);
                
                Console.WriteLine("Sending message, using 'A' as the first frame");


                client.SendMoreFrame("A").SendFrame("I am saying");

                var message = client.ReceiveFrameString();
                Console.WriteLine("Received {0}", message);

                Console.WriteLine("Sending message, using 'B' as the first frame");

                client.SendMoreFrame("B").SendFrame(", world!");

                message = client.ReceiveFrameString();
                Console.WriteLine("Received {0}", message);

                client.SendMoreFrame("C").SendFrame(", world!");

                message = client.ReceiveFrameString();
                Console.WriteLine("Received {0}", message);


                //waiting so the tester can see the console 
                Console.ReadKey();
            }
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;

namespace custom_async
{
    class Program
    {
        static void Main(string[] args)
        {

            //var SoProxyHelper = new ProxyHelper(ServerModule.ServerModuleType.SlaveOwner);
            //var FileProxyHelper = new ProxyHelper(ServerModule.ServerModuleType.FileServer);
            //var SMProxyHelper = new ProxyHelper(ServerModule.ServerModuleType.ServerModule);
            //var slaveProxyHelper = new ProxyHelper();

            var sm = new ServerModule();
            var so = new SlaveOwnerSM();
            var fsm = new FileSM();
            var slave = new Slave();

            sm.Setup(sm);
            so.Setup(sm);
            fsm.Setup(sm);
            slave.Setup(so);

            slave.GetInformationFromSlaveOwner();
             slave.MakeSODoSomethingElse();
            Console.ReadKey();

            //SoProxyHelper.Setup(sm, so);
            //FileProxyHelper.Setup(sm, fsm);
            //SMProxyHelper.Setup(sm, sm);
            //slaveProxyHelper.Setup(sm,slave )

            //sm.Setup();
            //so.Setup();
            //fsm.Setup();


            ////so.

            ////so.Start();

            //slave.Setup(slaveProxyHelper);

            //slave.GetInformationFromSlaveOwner();
        }

        public static void ReciveMessageInSlave(Message message)
        {
            
        }

    }
}

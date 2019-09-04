using System;
using System.Threading;
using System.Threading.Tasks;

namespace custom_async
{
    class Program
    {
        static void Main(string[] args)
        {

            var SoProxyHelper = new ProxyHelper(ServerModule.ModuleType.SlaveOwner);
            var FileProxyHelper = new ProxyHelper(ServerModule.ModuleType.FileServer);
            var SMProxyHelper = new ProxyHelper(ServerModule.ModuleType.ServerModule);

            var sm = new ServerModule();
            var so = new SlaveOwnerSM();
            var fsm = new FileSM();

            SoProxyHelper.Setup(sm, so);
            FileProxyHelper.Setup(sm, fsm);
            SMProxyHelper.Setup(sm, sm);

            so.

            so.Start();

            var slave = new Slave(so);
            slave.GetInformationFromSlaveOwner();
        }

        public static void ReciveMessageInSlave(Message message)
        {
            
        }

    }
}

using custom_async.modules;
using custom_async.proxies;
using System;
using System.Collections.Generic;
using System.Text;

namespace custom_async
{
    public class Slave : BaseClientModule
    {
        Dictionary<int, Action<object>> callIDToCallBack = new Dictionary<int, Action<object>>();

        public Slave() : base( ModuleType.Slave)
        {
        }





        //TODO this is the method that will be called to test everything
        public void GetInformationFromSlaveOwner()
        {
            new SlaveOwnerProxy(base.communicationHub, base.proxyHelper, this).GetTheDataForSlave(ReciveInformationFromSlaveOwner);
        }
        private void ReciveInformationFromSlaveOwner(string response)
        {
            Console.WriteLine("I got the response from the slave owner in the callback: " + response);
        }


        public void MakeSODoSomethingElse()
        {
            new SlaveOwnerProxy(base.communicationHub, base.proxyHelper, this).DoSomethingElse(HandleResponseFromSomethingElse);
        }
        private void HandleResponseFromSomethingElse(int num)
        {
            Console.WriteLine("Num from serverModule: " + num);
        }


    }
}

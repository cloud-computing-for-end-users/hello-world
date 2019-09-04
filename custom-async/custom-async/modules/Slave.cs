using System;
using System.Collections.Generic;
using System.Text;

namespace custom_async
{
    public class Slave : BaseModule
    {
        private SlaveOwnerSM so;
        private int moduleID = -1;

        Dictionary<int, Action<object>> callIDToCallBack = new Dictionary<int, Action<object>>();

        public Slave(SlaveOwnerSM so)
        {
            this.so = so;
            this.so.RegisterSlave(this.moduleID, this);
        }

        //TODO this is the method that will be called to test everything
        public void GetInformationFromSlaveOwner()
        {
            var message = new Message()
            {
                SenderModuleID = this.moduleID,
                CallID = 1,
                TargetModuleID = 1,
                TheMessage = "I want"
            };
            callIDToCallBack.Add(message.CallID, GotInformationFromSlaveOwner);
            so.ReciveMessage(message);
        }

        public virtual void GotInformationFromSlaveOwner(object str)
        {
            if(str is string _str)
            {
                Console.WriteLine("A catually got the infromation from the slave server: ");
                Console.WriteLine(_str);
            }

        }

        public override void HandleRequest(Message message)
        {
            throw new NotImplementedException();
        }

        //Console.WriteLine("The slave got a reponse to its call: " + message.TheMessage);


        public void ReciveMessage(Message message)
        {
            callIDToCallBack[message.CallID].Invoke(message.TheMessage);
        }

        public override void Setup(ProxyHelper proxyHelper)
        {
            throw new NotImplementedException();
        }
    }
}

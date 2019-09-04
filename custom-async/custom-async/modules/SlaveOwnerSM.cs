using System;
using System.Collections.Generic;
using System.Text;

namespace custom_async
{
    public class SlaveOwnerSM : BaseModule
    {
        //public ServerModule serverModule;
        private FileServerProxy fileServerProxy;

        public int moduleID = 1;

        Dictionary<int, Action<Message>> callIDToResponseHandler = new Dictionary<int, Action<Message>>();
        Dictionary<int, Slave> slaveBySlaveID = new Dictionary<int, Slave>();

        private ProxyHelper proxyHelper;
        public SlaveOwnerSM()
        {

        }

        public void TestMethod()
        {
            this.fileServerProxy.GetInformationForSlave()
        }

        //public override void Start()
        //{
        //    var proxyHelper = new ProxyHelper();
        //    proxyHelper.Setup(this.serverModule, this);

        //    this.fileServerProxy = new FileServerProxy(serverModule, proxyHelper);
        //}

        private static bool IsModuleIDForSlave(int moduleID)
        {
            return moduleID < 0;
        }

        public void RegisterSlave(int id, Slave slave)
        {
            slaveBySlaveID.Add(id, slave);
        }

        //public void ReciveMessage(Message message)
        //{
        //    if (this.moduleID == message.TargetModuleID
        //        && this.moduleID == message.SenderModuleID
        //        )
        //    {

        //        //a response for a request made by this module
        //        if (callIDToResponseHandler.ContainsKey(message.CallID))
        //        {
        //            //this response is needed or a request made to us.
        //            var callBackOnResponse = callIDToResponseHandler[message.CallID];
        //            callBackOnResponse.Invoke(message);

        //        }

        //    }
        //    else if(this.moduleID == message.TargetModuleID)
        //    {
        //        // a request made for this module
        //        if(message.TheMessage.Equals("I want"))
        //        {

        //            GetInformationForSlave( message);
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception("got message not targeted for me");
        //    }
        //}

        public override void HandleRequest(Message message)
        {
            Console.WriteLine("A request was made to the slave owner");
            var response = new Response()
            {
                CallID = message.CallID,
                IntendedTargetModuleID = message.SenderModuleID,
                TheResponse = "this is my response"
            };
            this.proxyHelper.SendSendable(response);
        }

        public override void Setup(ProxyHelper proxyHelper)
        {
            this.proxyHelper = proxyHelper;
        }

        //public void GetInformationForSlave(Message request)
        //{
        //    //to do this I need to get some from the file server



        //    Action<Message> callBack = msg => {
        //        //what needs to be done with the result from the subreQuest

        //        var slave = slaveBySlaveID[request.SenderModuleID];
        //        msg.TheMessage = msg.TheMessage + " + I got some closure aswell";
        //        msg.CallID = request.CallID;
        //        msg.SenderModuleID = request.SenderModuleID;
        //        msg.TargetModuleID = request.SenderModuleID;
        //        slave.ReciveMessage(msg);

        //    };

        //    var message = new Message()
        //    {
        //        SenderModuleID = this.moduleID,
        //        CallID = 1,
        //        TargetModuleID = 3,
        //        TheMessage = "Hey mr. file server I need that info for the slave"
        //    };

        //    callIDToResponseHandler.Add(message.CallID, callBack);

        //    serverModule.ReciveMessage(message);
        //}

    }
}

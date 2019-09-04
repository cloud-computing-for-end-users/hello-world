using System;
using System.Collections.Generic;
using System.Text;

namespace custom_async
{
    public class ServerModuleProxy : BaseProxy
    {
        private ProxyHelper proxyHelper;
        public ServerModuleProxy(ProxyHelper proxyHelper)
        {
            this.proxyHelper = proxyHelper;


        }






        //ServerModule serverModule;
        //ProxyHelper proxyHelper;
        //Dictionary<int, Action<Message>> callIDToResponseHandler = new Dictionary<int, Action<Message>>();


        //public ServerModuleProxy(ProxyHelper proxyHelper)
        //{
        //    this.serverModule = serverModule;
        //    this.proxyHelper = proxyHelper;
        //}

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
        //    else if (this.moduleID == message.TargetModuleID)
        //    {
        //        // a request made for this module
        //        if (message.TheMessage.Equals("I want"))
        //        {

        //            GetInformationForSlave(message);
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception("got message not targeted for me");
        //    }
        //}
        public void GiveResponse(Message message)
        {
            this.proxyHelper.SendMessage(message,)
            throw new NotImplementedException();
        }

        public override void HandleMessage(Message message)
        {
            throw new NotImplementedException();
        }
    }
}

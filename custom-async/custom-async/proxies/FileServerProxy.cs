using System;
using System.Collections.Generic;
using System.Text;

namespace custom_async
{
    public class FileServerProxy : BaseProxy
    {
        //ServerModule serverModule;
        ProxyHelper proxyHelper;
        BaseModule baseServermodule;
        Dictionary<int, Action<Message>> callIDToResponseHandler = new Dictionary<int, Action<Message>>();


        public FileServerProxy(
            //ServerModule serverModule,
            BaseModule baseServermodule,
            ProxyHelper proxyHelper)
        {
            //this.serverModule = serverModule;
            this.proxyHelper = proxyHelper;
            this.baseServermodule = baseServermodule;
        }

        public void GetInformationForSlave(Action<string> callBack)
        {
            //to do this I need to get some from the file server

            Action<Response> localCallBack = res => {
                //what needs to be done with the result from the subreQuest

                var slave = slaveBySlaveID[request.SenderModuleID];
                msg.TheMessage = msg.TheMessage + " + I got some closure aswell";
                msg.CallID = request.CallID;
                msg.SenderModuleID = request.SenderModuleID;
                msg.TargetModuleID = request.SenderModuleID;
                slave.ReciveMessage(msg);

            };

            var message = new Message()
            {
                SenderModuleID = this.proxyHelper.ModuleID,
                CallID = 1,
                TargetModuleType = ServerModule.ModuleType.FileServer,
                TheMessage = "Hey mr. file server I need that info for the slave"
            };

            callIDToResponseHandler.Add(message.CallID, localCallBack);

            serverModule.ReciveMessage(message);
        }

        public override void HandleResponse(Response message)
        {
            throw new NotImplementedException();
        }

        public void ReciveMessage(Message message)
        {
            if (this.moduleID == message.TargetModuleID
                && this.moduleID == message.SenderModuleID
                )
            {

                //a response for a request made by this module
                if (callIDToResponseHandler.ContainsKey(message.CallID))
                {
                    //this response is needed or a request made to us.
                    var callBackOnResponse = callIDToResponseHandler[message.CallID];
                    callBackOnResponse.Invoke(message);

                }

            }
            else if (this.moduleID == message.TargetModuleID)
            {
                // a request made for this module
                if (message.TheMessage.Equals("I want"))
                {

                    GetInformationForSlave(message);
                }
            }
            else
            {
                throw new Exception("got message not targeted for me");
            }
        }

    }
}

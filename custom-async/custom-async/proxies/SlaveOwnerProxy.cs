using System;
using System.Collections.Generic;
using System.Text;

namespace custom_async.proxies
{
    //I THINK THIS PROXY IS ACTUALLY RIGHT
    public class SlaveOwnerProxy : BaseProxy
    {
        public SlaveOwnerProxy(
            BaseModule baseServermodule,
            ProxyHelper proxyHelper
            )
        {
            //this.serverModule = serverModule;
            this.proxyHelper = proxyHelper;
            this.baseServermodule = baseServermodule;
        }

        public void GetTheDataForSlave(Action<string> callBack)
        {
            int callID = base.GenerateAndReserveCallID();
            var messageToSend = new Message()
            {
                SenderModuleID = base.proxyHelper.ModuleID,
                CallID = callID,
                TargetModuleType = ServerModule.ModuleType.SlaveOwner

            };

            Action<Response> theCallBack = res =>
            {
                callBack.Invoke(res.TheResponse + "I got enclosed");

            };

            base.callIDToResponseHandler[callID] = theCallBack;

            base.proxyHelper.SendMessage(messageToSend, this);
        }

        public override void HandleResponse(Response response)
        {
            if (base.callIDToResponseHandler.ContainsKey(response.CallID))
            {
                //handle the response
                callIDToResponseHandler[response.CallID].Invoke(response);
            }

            throw new Exception("That response is not recognised");
        }
    }
}

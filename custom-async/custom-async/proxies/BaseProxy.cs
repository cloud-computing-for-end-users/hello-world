using custom_async.modules;
using System;
using System.Collections.Generic;
using System.Text;
using static custom_async.modules.BaseModule;

namespace custom_async
{
    public abstract class BaseProxy
    {

        protected ProxyHelper proxyHelper;
        protected BaseModule baseModule;
        protected BaseRouterModule baseRouterModule;

        protected Dictionary<int, Action<Response>> callIDToResponseHandler;

        public BaseProxy(BaseRouterModule baseRouterModule, ProxyHelper proxyHelper, BaseModule baseModule)
        {
            this.proxyHelper = proxyHelper;
            this.baseRouterModule = baseRouterModule;
            this.baseModule = baseModule;

            callIDToResponseHandler = new Dictionary<int, Action<Response>>();
        }

        //public abstract void HandleMessage(Message message);
        public void HandleResponse(Response response)
        {
            this.callIDToResponseHandler[response.CallID].Invoke(response);

        }

        protected int GenerateAndReserveCallID()
        {
            int callID = 0;
            do
            {
                callID = new Random().Next();
            } while (callIDToResponseHandler.ContainsKey(callID));
            callIDToResponseHandler.Add(callID, null);
            return callID;
        }

        protected abstract void SendMessage(Action<Response> callBack, string payload);
        protected void SendMessage(Action<Response> callBack,ModuleType targetModuleType, string payload)
        {
            var message = new Message()
            {
                SenderModuleID = this.proxyHelper.ModuleID,
                CallID = this.GenerateAndReserveCallID(),
                TargetModuleType = targetModuleType,
                TheMessage = payload
            };


            this.callIDToResponseHandler[message.CallID] = callBack;
            this.proxyHelper.SendMessage(message, this);
        }

    }
}

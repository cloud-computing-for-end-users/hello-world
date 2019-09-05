using custom_async.modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace custom_async
{
    public class ProxyHelper
    {
        private BaseRouterModule routerModule;
        private BaseModule baseModule;

        public int ModuleID { get { return baseModule.ModuleID; } }

        //public static readonly ProxyHelper INSTANCE = new ProxyHelper();
        private Dictionary<int, BaseProxy> callIDToReponseHandler = new Dictionary<int, BaseProxy>();

        public ProxyHelper()
        {
        }

        public void Setup(BaseRouterModule routerModule, BaseModule baseModule)
        {
            this.routerModule = routerModule;
            this.baseModule = baseModule;
        }

        public void SendResponse(Response response)
        {
            this.routerModule.HandleSendable(response);

        }
        public void SendMessage(Message message, BaseProxy baseProxy)
        {
            //var callID = new Random().Next();

            callIDToReponseHandler.Add(message.CallID, baseProxy);
            routerModule.HandleSendable(message);
            //return callID;
        }

        public void ReciveSendable(Sendable sendable)
        {
            if (sendable is Message message)
            {
                //this is a request
                if (baseModule is BaseServerModule _baseServerModule)
                {
                    _baseServerModule.HandleRequest(message);
                }
                else
                {
                    throw new Exception("Not supported");
                }
            }
            else if (sendable is Response response)
            {
                if (callIDToReponseHandler.ContainsKey(response.CallID))
                {
                    //this is a response made to a request
                    callIDToReponseHandler[response.CallID].HandleResponse(response);
                }

            }
        }

    }
}

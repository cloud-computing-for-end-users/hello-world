using System;
using System.Collections.Generic;
using System.Text;
using static custom_async.ServerModule;

namespace custom_async
{
    public class ProxyHelper
    {
        ServerModule serverModule;
        BaseModule baseServermodule;

        private int moduleID;
        public int ModuleID { get { return this.moduleID; } }

        //public static readonly ProxyHelper INSTANCE = new ProxyHelper();
        private Dictionary<int, BaseProxy> callIDToReponseHandler = new Dictionary<int, BaseProxy>();

        public ProxyHelper(ModuleType moduleType)
        {
            this.moduleID = ServerModule.RegisterModule(moduleType, this);

        }

        public void Setup(ServerModule serverModule, BaseModule baseServermodule)
        {
            this.serverModule = serverModule;
            this.baseServermodule = baseServermodule;
        }

        public void SendResponse(Response response)
        {
            this.serverModule.HandleResponse(response);

        }
        public int SendMessage(Message message, BaseProxy baseProxy)
        {
            var callID = new Random().Next();

            callIDToReponseHandler.Add(callID, baseProxy);
            return callID;
        }

        public void ReciveSendable(Sendable sendable)
        {
            if (sendable is Message message)
            {
                //this is a request
                this.baseServermodule.HandleRequest(message);
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

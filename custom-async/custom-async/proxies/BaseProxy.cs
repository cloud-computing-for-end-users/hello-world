using System;
using System.Collections.Generic;
using System.Text;

namespace custom_async
{
    public abstract class BaseProxy
    {

        protected ProxyHelper proxyHelper;
        protected BaseModule baseServermodule;

        protected Dictionary<int, Action<Response>> callIDToResponseHandler;

        public BaseProxy()
        {
            callIDToResponseHandler = new Dictionary<int, Action<Response>>();
        }

        //public abstract void HandleMessage(Message message);
        public abstract void HandleResponse(Response message);

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

    }
}

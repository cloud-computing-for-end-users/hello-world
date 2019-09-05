using custom_async.modules;
using System;
using System.Collections.Generic;
using System.Text;
using static custom_async.ServerModule;

namespace custom_async
{
    public abstract class BaseServerModule : BaseModule
    {

        public BaseServerModule(ModuleType moduleType) : base(moduleType)
        {
        }

        public abstract void HandleRequest(Message message);


        protected virtual void SendResponse(Response response)
        {
            throwExceptionIfMissiongSetupCall();

            base.proxyHelper.SendResponse(response);
        }

        protected Response GenerateResponseBasedOnMessageAndPayload(Message message, object responsePayload)
        {
            return new Response()
            {
                CallID = message.CallID,
                IntendedTargetModuleID = message.SenderModuleID,
                SenderModuleID = base.moduleID,
                TheResponse = responsePayload
            };
        }

    }
}

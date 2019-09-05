using custom_async.modules;
using System;
using System.Collections.Generic;
using System.Text;
using static custom_async.ServerModuleProxy;

namespace custom_async
{
    public class ServerModule : BaseRouterModule
    {


        public ServerModule() : base(ModuleType.ServerModule)
        {


        }

        public override void HandleRequest(Message message)
        {
            //this should be called
            if(Const.REQ_FROM_SLAVE_OWNER_DO_SMTH_ELSE == message.TheMessage)
            {
                HandleDoSmthElse(message);
            }
        }

        private void HandleDoSmthElse(Message message)
        {
            var res = GenerateResponseBasedOnMessageAndPayload(message, 42);
            SendResponse(res);

        }

   
    }
}

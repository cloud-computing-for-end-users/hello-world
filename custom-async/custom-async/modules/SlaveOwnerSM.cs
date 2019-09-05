using custom_async.modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace custom_async
{
    public class SlaveOwnerSM : BaseRouterModule
    {
        public SlaveOwnerSM() : base(ModuleType.SlaveOwnerServermodule)
        {

        }

        public override void HandleRequest(Message message)
        {
            if (message.TheMessage.Equals(Const.REQ_FROM_SLAVE))
            {
                HandleRequestFromSlave(message);
            }else if (message.TheMessage.Equals(Const.REQ_SMTH_FROM_SO))
            {
                HandleDoSmtElse(message);
            }
        }

        private void HandleDoSmtElse(Message message)
        {
            new ServerModuleProxy(base.communicationHub, base.proxyHelper, this).DoSmth(num =>
             {
                 var response = GenerateResponseBasedOnMessageAndPayload(message, num);
                 SendResponse(response);

                 //this is else if because this is a also a router node
                 

             });
        }


        private void HandleRequestFromSlave(Message message)
        {
            new FileServerProxy(base.communicationHub, base.proxyHelper, this).GetInformationForSlave(payload =>
            {
                var response = GenerateResponseBasedOnMessageAndPayload(message, payload);
                SendResponse(response);
            });
        }

    }
}

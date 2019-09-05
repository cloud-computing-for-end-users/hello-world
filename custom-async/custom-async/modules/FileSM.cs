using System;
using System.Collections.Generic;
using System.Text;

namespace custom_async
{
    public class FileSM : BaseServerModule
    {
        public ServerModule serverModule;

        public FileSM() : base(ModuleType.FileServermodule)
        {
        }

        public override void HandleRequest(Message message)
        {
            if (message.TheMessage.Equals(Const.REQ_FROM_SLAVE_OWNER))
            {
                HandleReqFromSlaveOwner(message);
            }
        }

        private string GetThatInfoForTheSlave()
        {
            return "this is the info for the slave";
        }

        private void HandleReqFromSlaveOwner(Message message)
        {
            var response = new Response()
            {
                CallID = message.CallID,
                IntendedTargetModuleID = message.SenderModuleID,
                SenderModuleID = base.moduleID,
                TheResponse = GetThatInfoForTheSlave()
            };

            SendResponse(response);
        }
    }
}

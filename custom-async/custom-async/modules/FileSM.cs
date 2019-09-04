using System;
using System.Collections.Generic;
using System.Text;

namespace custom_async
{
    public class FileSM : BaseModule
    {
        public ServerModule serverModule;

        private int servermoduleID;

        ServerModuleProxy callsToServerModule;
        //SlaveOwnerProxy callsToSlaveOwner;

        public FileSM()
        {
            //this.serverModule = serverModule;
            //this.servermoduleID = ServerModule.RegisterModule(ServerModule.ModuleType.FileServer, this);
            //this.callsToServerModule = new ServerModuleProxy()
        }




        public int moduleID = 3;

        public void ReciveMessage(Message message)
        {

            if (this.moduleID == message.TargetModuleID)
            {
                //do what needs to be done and send a message back
                var res = GetThatInfoForTheSlave();

                var responseMEssage = new Message()
                {
                    SenderModuleID = message.SenderModuleID,
                    CallID = message.CallID,
                    TargetModuleID = 1,
                    TheMessage = res
                };
                serverModule.ReciveMessage(responseMEssage);

            }
            else
            {
                throw new Exception("got message not targeted for me");
            }
        }

        private void SendMessage(Message message)
        {

        }

        private string GetThatInfoForTheSlave()
        {
            return "this is the info for the slave";
        }
        private void Method2()
        {

        }

        public override void HandleRequest(Message message)
        {
            throw new NotImplementedException();
        }

        public override void Start()
        {
            throw new NotImplementedException();
        }
    }
}

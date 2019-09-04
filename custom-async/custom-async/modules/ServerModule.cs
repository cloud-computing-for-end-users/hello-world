using System;
using System.Collections.Generic;
using System.Text;
using static custom_async.ServerModuleProxy;

namespace custom_async
{
    public class ServerModule : BaseModule
    {
        public enum ModuleType
        {
            ServerModule,
            FileServer,
            SlaveOwner
        }

        private static Dictionary<int, ProxyHelper> moduleIdToProxyHelper = new Dictionary<int, ProxyHelper>();

        public static int RegisterModule(ModuleType targetType, ProxyHelper proxyHelper)
        {
            int moduleID = 0;
            do
            {
                moduleID = new Random().Next();
            } while (moduleIdToProxyHelper.ContainsKey(moduleID);
            return moduleID;
        }



        public SlaveOwnerSM slaveOwnerSM;
        public FileSM fileServermodule;
        public int moduleID = 2;



        public void ReciveMessage(Message message)
        {

            //send to so
            if(slaveOwnerSM.moduleID == message.TargetModuleID)
            {
                this.slaveOwnerSM.ReciveMessage(message);
            }else if(fileServermodule.moduleID == message.TargetModuleID)
            {
                fileServermodule.ReciveMessage(message);
            }else if(this.moduleID == message.TargetModuleID)
            {

            }
        }

        public void HandleResponse(Response response)
        {
            moduleIdToProxyHelper[response.CallID].Hand
        }

        public void SendMessage(Message message)
        {

        }

        private void Method1()
        {

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

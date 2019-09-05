using System;
using System.Collections.Generic;
using System.Text;
using static custom_async.ServerModule;

namespace custom_async.modules
{
    public abstract class BaseRouterModule : BaseServerModule
    {
        protected Dictionary<int, ProxyHelper> moduleIdToProxyHelper = new Dictionary<int, ProxyHelper>();
        protected Dictionary<ModuleType, ProxyHelper> moduleTypeToProxyHelper = new Dictionary<ModuleType, ProxyHelper>();

        public BaseRouterModule(ModuleType type) : base(type)
        {

        }

        protected override void SendResponse(Response response)
        {
            if (this.moduleIdToProxyHelper.ContainsKey(response.IntendedTargetModuleID))
            {
                this.moduleIdToProxyHelper[response.IntendedTargetModuleID].ReciveSendable(response);
            }
            else
            {
                base.SendResponse(response);
            }
        }


        public void HandleSendable(Sendable sendable)
        {
            throwExceptionIfMissiongSetupCall();

            if (sendable is Message message)
            {
                if (base.moduleType == message.TargetModuleType)
                {
                    //handle request
                    HandleRequest(message);

                }
                else
                {
                    //forward the message
                    ForwardSendable(message);

                }
            }
            else if (sendable is Response response)
            {
                if (base.moduleID == response.IntendedTargetModuleID)
                {
                    //response for self
                    //HandleResponse(response);
                    throw new Exception("Do I need this?");
                }
                else
                {
                    ForwardSendable(response);
                }

            }
        }
        protected void ForwardSendable(Sendable sendable)
        {
            throwExceptionIfMissiongSetupCall();

            if (sendable is Message message)
            {
                this.moduleTypeToProxyHelper[message.TargetModuleType].ReciveSendable(sendable);
            }
            else if (sendable is Response response)
            {
                this.moduleIdToProxyHelper[response.IntendedTargetModuleID].ReciveSendable(sendable);

            }
        }



        public int RegisterModule(ModuleType mouleType, ProxyHelper proxyHelper)
        {

            int moduleID = 0;
            do
            {
                moduleID = new Random().Next();
            } while (moduleIdToProxyHelper.ContainsKey(moduleID));


            moduleTypeToProxyHelper.Add(mouleType, proxyHelper);
            moduleIdToProxyHelper.Add(moduleID, proxyHelper);

            return moduleID;
        }
    }
}

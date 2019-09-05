using System;
using System.Collections.Generic;
using System.Text;

namespace custom_async.modules
{
    public abstract class BaseModule
    {
        protected ProxyHelper proxyHelper;
        protected int moduleID;
        protected ModuleType moduleType;
        protected BaseRouterModule communicationHub;
        protected bool SetupHasBeenCalled = false;

        public int ModuleID { get { return this.moduleID; } }

        public enum ModuleType
        {
            ServerModule,
            FileServermodule,
            SlaveOwnerServermodule,
            DatabaseServermodule,
            Slave,
            Client
        }

        protected void throwExceptionIfMissiongSetupCall()
        {
            if (false == SetupHasBeenCalled)
            {
                throw new Exception("The setup method must be called");
            }
        }


        public BaseModule(ModuleType moduleType)
        {
            this.moduleType = moduleType;
            this.proxyHelper = new ProxyHelper();
        }

        public virtual void Setup(BaseRouterModule baseRouterModule)
        {
            SetupHasBeenCalled = true;

            this.communicationHub = baseRouterModule;

            this.proxyHelper = new ProxyHelper();
            this.proxyHelper.Setup(baseRouterModule, this);
            this.moduleID = this.communicationHub.RegisterModule(this.moduleType, this.proxyHelper);

        }

        //public abstract void HandleResponse(Response response);
    }
}

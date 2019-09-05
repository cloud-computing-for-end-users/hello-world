using System;
using System.Collections.Generic;
using System.Text;
using custom_async.modules;

namespace custom_async
{
    public class ServerModuleProxy : BaseProxy
    {
        private ProxyHelper proxyHelper;

        public ServerModuleProxy(BaseRouterModule baseRouterModule, ProxyHelper proxyHelper, BaseModule baseModule) : base(baseRouterModule, proxyHelper, baseModule)
        {
        }

        protected override void SendMessage(Action<Response> callBack, string payload)
        {
            base.SendMessage(callBack, BaseModule.ModuleType.ServerModule, payload);
        }

        public void DoSmth(Action<int> callBack)
        {
            Action<Response> theCallBack = res =>
            {
                callBack.Invoke(Convert.ToInt32(res.TheResponse));

            };

            SendMessage(theCallBack, Const.REQ_FROM_SLAVE_OWNER_DO_SMTH_ELSE);

        }
    }
}

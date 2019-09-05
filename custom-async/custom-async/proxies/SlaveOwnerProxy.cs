using custom_async.modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace custom_async.proxies
{
    //I THINK THIS PROXY IS ACTUALLY RIGHT
    public class SlaveOwnerProxy : BaseProxy
    {
        public SlaveOwnerProxy(BaseRouterModule baseRouterModule, ProxyHelper proxyHelper, BaseModule baseModule) : base(baseRouterModule, proxyHelper, baseModule)
        {
        }

        protected override void SendMessage(Action<Response> callBack, string payload)
        {
            base.SendMessage(callBack, BaseModule.ModuleType.SlaveOwnerServermodule, payload);
        }

        public void GetTheDataForSlave(Action<string> callBack)
        {
            Action<Response> theCallBack = res =>
            {
                callBack.Invoke(res.TheResponse + "I got enclosed");

            };
            SendMessage(theCallBack, Const.REQ_FROM_SLAVE);
        }

        public void DoSomethingElse(Action<int> callBack)
        {
            Action<Response> theCallBack = res =>
            {
                callBack.Invoke(Convert.ToInt32(res.TheResponse));

            };

            SendMessage(theCallBack, Const.REQ_SMTH_FROM_SO);
        }
    }
}

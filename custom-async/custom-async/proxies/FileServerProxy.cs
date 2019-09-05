using custom_async.modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace custom_async
{
    public class FileServerProxy : BaseProxy
    {
        //ServerModule serverModule;


        public FileServerProxy( BaseRouterModule baseRouterModule,ProxyHelper proxyHelper,BaseModule baseModule) : base(baseRouterModule,proxyHelper, baseModule )
        {

        }

        public void GetInformationForSlave(Action<string> callBack)
        {
            //to do this I need to get some from the file server

            Action<Response> localCallBack = res =>
            {
                //what needs to be done with the result from the subreQuest
                callBack.Invoke(res.TheResponse as string);
            };

            string payload = Const.REQ_FROM_SLAVE_OWNER;
            SendMessage(localCallBack,  payload);
        }

        protected override void SendMessage(Action<Response> callBack, string payload)
        {
            base.SendMessage(callBack, modules.BaseModule.ModuleType.FileServermodule, payload);
        }
    }
}

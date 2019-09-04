using System;
using System.Collections.Generic;
using System.Text;

namespace custom_async
{
    public abstract class BaseModule
    {

        //public abstract void HandleResponse(Response response);
        public abstract void HandleRequest(Message message);

        //public abstract void Start();

        public abstract void Setup(ProxyHelper proxyHelper);
    }
}

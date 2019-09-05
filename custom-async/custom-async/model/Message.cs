using System;
using System.Collections.Generic;
using System.Text;
using static custom_async.modules.BaseModule;
using static custom_async.ServerModule;

namespace custom_async
{
    public class Message : Sendable
    {
        public ModuleType TargetModuleType { get; set; }
        public string TheMessage { get; set; }
    }
}

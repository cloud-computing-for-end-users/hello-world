using System;
using System.Collections.Generic;
using System.Text;

namespace custom_async
{
    public class Message : Sendable
    {
        public int SenderModuleID { get; set; }
        public int CallID{ get; set; }
        public int TargetModuleID { get; set; }

        public string TheMessage { get; set; }
    }
}

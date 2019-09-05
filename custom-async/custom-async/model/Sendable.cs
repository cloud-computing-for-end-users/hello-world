using System;
using System.Collections.Generic;
using System.Text;

namespace custom_async
{
    public abstract class Sendable
    {
        public int SenderModuleID { get; set; }
        public int CallID { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace custom_async
{
    public class Response : Sendable
    {
        public int IntendedTargetModuleID { get; set; }
        public object TheResponse { get; set; }

    }
}

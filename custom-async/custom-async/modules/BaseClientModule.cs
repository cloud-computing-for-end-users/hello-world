using System;
using System.Collections.Generic;
using System.Text;

namespace custom_async.modules
{
    public abstract class BaseClientModule : BaseModule
    {
        //the module type must be Slave or client atm
        public BaseClientModule(ModuleType moduleType) : base(moduleType)
        {

        }
    }
}

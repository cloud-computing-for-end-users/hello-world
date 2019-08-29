using System;
using System.Collections.Generic;
using System.Text;

namespace hello_world_json_net_serializer
{
    public class Account
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<string> Roles { get; set; }
        public Name MaName { get; set; }
    }
}

﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace hello_world_json_net_serializer
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account
            {
                Email = "james@example.com",
                Active = true,
                CreatedDate = new DateTime(2013, 1, 20, 0, 0, 0, DateTimeKind.Utc),
                Roles = new List<string> { "User", "Admin" },
                MaName = new Name()
                {
                    TheName = "Kenneth"
                }
            };

            string json = JsonConvert.SerializeObject(account, Formatting.Indented );
            Console.WriteLine(json);

            var obj = JsonConvert.DeserializeObject(json, typeof(Account));
            if(obj is Account _acc)
            {
                Console.WriteLine("Account email: " + _acc.MaName.TheName);
                Console.WriteLine("Account dewerialised sucessfully");
            }




            Console.ReadKey();
        }
    }
}

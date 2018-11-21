using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackApi.Model
{
    public class Account
    {
        public string CloudName { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }

        public Account() { }

        public Account(string cloudName,string apiKey,string apiSecret) {
            CloudName = cloudName;
            ApiKey = apiKey;
            ApiSecret = ApiSecret;
        }
    }
}

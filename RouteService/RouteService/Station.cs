using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace RouteService
{
    class Station
    {
        public int number;
        public String name;
        public String contractName;
        public String address;
        public JObject position;
        public bool banking;
        public bool bonus;
        public String status;
        public bool connected;
        public JObject totalStands;
        public JObject mainStands;
    }
}

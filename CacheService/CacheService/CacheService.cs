using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Timers;
using Newtonsoft.Json;

namespace CacheService
{
     class CacheService : ICacheService
    {
        public Data data;
        public String city;

        public void InitCache()
        {
            data = new Data();

        }

        public void InitCity(String city)
        {
            data.SetCity(city);
        }
        

        public List<String> GetCities()
        {
            return data.GetCities();
        }

        public Data GetData()
        {
            return data;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using CacheService;

namespace CacheService
{

    [ServiceContract]
    interface ICacheService
    {
        [OperationContract]
        void InitCache();

        [OperationContract]
        void InitCity(String city);


        [OperationContract]
        List<String> GetCities();

        [OperationContract]
        Data GetData();

        
    }
}

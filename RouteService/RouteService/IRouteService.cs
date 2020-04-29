using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace RouteService
{
    [ServiceContract]
    interface IRouteService
    {
        [OperationContract]
        void InitCache();

        [OperationContract]
        void InitCity(String city);

        [OperationContract]
        void SearchRoute(String origin, String destination, String stations);

        [OperationContract]
        String[] GetCities();
    }
}

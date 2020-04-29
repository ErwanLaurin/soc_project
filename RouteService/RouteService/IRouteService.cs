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
        String SearchRoute(String origin, String destination);

        [OperationContract]
        String[] GetCities();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RouteService.CacheService;

namespace RouteService
{
    
    class RouteService : IRouteService
    {
        CacheServiceClient client = new CacheServiceClient();
        String city;

        public void InitCache()
        {
            client.InitCache();            
        }

        public void InitCity(String city)
        {
            client.InitCity(city);
        }

        public void SearchRoute(String origin, String destination, String stations)
        {
            Route route = new Route(origin, destination, stations);
        }

        public String[] GetCities()
        {
            return client.GetCities();
        }
    }
}

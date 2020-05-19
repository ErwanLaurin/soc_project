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
            this.city = city;
        }

        public String SearchRoute(String origin, String destination)
        {
            dynamic stations = client.GetStations();
            Route route = new Route(origin +" "+city, destination+" "+city, stations);
            return route.GetRoute();
        }

        public String[] GetCities()
        {
            return client.GetCities();
        }
    }
}

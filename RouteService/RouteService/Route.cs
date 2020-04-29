using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RouteService
{
    public class Route
    {
        private String origin;
        private String destination;
        private JObject originPosition;
        private JObject destinationPosition;
        private List<Station> stations;

        public Route(String origin, String destination, String stations)
        {
            this.origin = origin;
            this.destination = destination;
            this.stations = new List<Station>();
            JObject[] array = JsonConvert.DeserializeObject<JObject[]>(stations);
            System.Diagnostics.Debug.WriteLine(array);
            foreach (var obj in array)
            {
                Station station = JsonConvert.DeserializeObject<Station>(obj.ToString());
                this.stations.Add(station);
            }
        }

        public String GetRoute()
        {
            return stations[0].name;   
        }

        public void GetPositions()
        {
            String originFromServer = SendRequest("https://maps.googleapis.com/maps/api/geocode/json?address=" + origin + "&key=AIzaSyBFi_OOzvJwO0T1rAvScP18I_vQOL8mJS0");
            String destinationFromServer = SendRequest("https://maps.googleapis.com/maps/api/geocode/json?address=" + destination + "&key=AIzaSyBFi_OOzvJwO0T1rAvScP18I_vQOL8mJS0");
            dynamic obj1 = JsonConvert.DeserializeObject(originFromServer);
            dynamic obj2 = JsonConvert.DeserializeObject(destinationFromServer);
            originPosition = obj1.results[0].geometry.location;
            destinationPosition = obj2.results[0].geometry.location;
        }

        public JObject GetOriginPosition()
        {
            return originPosition;
        }

        public JObject GetDestinationPosition()
        {
            return destinationPosition;
        }

        public String SendRequest(String url)
        {
            WebRequest request = WebRequest.Create(url);
            //request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();
            return responseFromServer;
        }
    }
}

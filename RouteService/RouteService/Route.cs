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
        private String apiKey = "AIzaSyBFi_OOzvJwO0T1rAvScP18I_vQOL8mJS0";

        public Route(String origin, String destination, String stations)
        {
            this.origin = origin;
            this.destination = destination;
            this.stations = new List<Station>();
            JObject[] array = JsonConvert.DeserializeObject<JObject[]>(stations);
            foreach (var obj in array)
            {
                Station station = JsonConvert.DeserializeObject<Station>(obj.ToString());
                this.stations.Add(station);
            }
        }

        public String GetRoute()
        {
            Station start = NearestStation(origin);
            Station end = NearestStation(destination);
            String startResponse = SendRequest("https://maps.googleapis.com/maps/api/distancematrix/json?mode=walking&units=metric&origins=" + origin + "&destinations=" + start + start.contractName + "&key=" + apiKey);
            JObject result1 = JsonConvert.DeserializeObject<JObject>(startResponse);
            System.Diagnostics.Debug.WriteLine(result1.ToString());
            String endResponse = SendRequest("https://maps.googleapis.com/maps/api/distancematrix/json?mode=walking&units=metric&origins=" + end+ end.contractName + "&destinations=" + destination + "&key=" + apiKey);
            JObject result2 = JsonConvert.DeserializeObject<JObject>(endResponse);
            System.Diagnostics.Debug.WriteLine(result2.ToString());
            String bikeResponse = SendRequest("https://maps.googleapis.com/maps/api/distancematrix/json?mode=bicycling&units=metric&origins=" + start+ start.contractName + "&destinations=" + end+end.contractName + "&key=" + apiKey);
            JObject result3 = JsonConvert.DeserializeObject<JObject>(bikeResponse);
            System.Diagnostics.Debug.WriteLine(result3.ToString());
            String route = "Départ : " + origin + ",\r\n marcher pendant " + result1["rows"][0]["elements"][0]["distance"]["text"].ToString() + " jusqu'à "+start.address+",\r\n prendre le vélo pendant "+result3["rows"][0]["elements"][0]["distance"]["text"].ToString()+"jusqu'à "+end.address+",\r\n puis marcher pendant "+ result2["rows"][0]["elements"][0]["distance"]["text"].ToString()+" jusqu'à " +destination+" (Arrivée).";
            return route;   
        }

        public Station NearestStation(String position)
        {
            String destinations = "";
            foreach(Station station in stations)
            {
                destinations += station.address + " " +station.contractName+ "|";
            }
            //System.Diagnostics.Debug.WriteLine(destinations);
            String response = SendRequest("https://maps.googleapis.com/maps/api/distancematrix/json?mode=walking&units=metric&origins=" + position + "&destinations=" + destinations + "&key=" + apiKey);
            JObject result = JsonConvert.DeserializeObject<JObject>(response);
            //System.Diagnostics.Debug.WriteLine(result);
            Station nearest;
            Double min = -1;
            String minDist;
            String minDur;
            int minIndex = -1;
            int i = -1;
            foreach(JObject obj in result["rows"][0]["elements"])
            {
                i++;
                //System.Diagnostics.Debug.WriteLine(obj.ToString());
                String duration = obj["duration"]["text"].ToString();
                String distance = obj["distance"]["text"].ToString();
                String dist = distance.Split(' ').First();
                dist = dist.Replace(",", "");
                dist = dist.Replace(".", ",");
                Double distNum = Convert.ToDouble(dist);
                if (min < 0 || distNum < min)
                {
                    minDist = distance;
                    minDur = duration;
                    minIndex = i;
                }
            }
            nearest = stations[minIndex];
            return nearest;
        }

        public void GetPositions()
        {
            String originFromServer = SendRequest("https://maps.googleapis.com/maps/api/geocode/json?address=" + origin + "&key="+apiKey);
            String destinationFromServer = SendRequest("https://maps.googleapis.com/maps/api/geocode/json?address=" + destination + "&key="+apiKey);
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

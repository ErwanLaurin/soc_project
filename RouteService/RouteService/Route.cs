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
        private List<String> elevation;
        private String apiKey = "AIzaSyBFi_OOzvJwO0T1rAvScP18I_vQOL8mJS0";

        public Route(String origin, String destination, String stations)
        {
            this.origin = origin;
            this.destination = destination;
            this.stations = new List<Station>();
            this.elevation = new List<String>();
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
            String startResponse = SendRequest("https://maps.googleapis.com/maps/api/distancematrix/json?mode=walking&units=metric&origins=" + origin + "&destinations=" + start.getPositionString() + "&key=" + apiKey);
            JObject result1 = JsonConvert.DeserializeObject<JObject>(startResponse);
            System.Diagnostics.Debug.WriteLine(result1.ToString());
            String endResponse = SendRequest("https://maps.googleapis.com/maps/api/distancematrix/json?mode=walking&units=metric&origins=" + end.getPositionString() + "&destinations=" + destination + "&key=" + apiKey);
            JObject result2 = JsonConvert.DeserializeObject<JObject>(endResponse);
            System.Diagnostics.Debug.WriteLine(result2.ToString());
            String bikeResponse = SendRequest("https://maps.googleapis.com/maps/api/distancematrix/json?mode=bicycling&units=metric&origins=" + start.getPositionString() + "&destinations=" + end.getPositionString() + "&key=" + apiKey);
            JObject result3 = JsonConvert.DeserializeObject<JObject>(bikeResponse);
            System.Diagnostics.Debug.WriteLine(result3.ToString());
            String route = "Départ : " + origin + ",\r\nmarcher pendant " + result1["rows"][0]["elements"][0]["distance"]["text"].ToString() + " jusqu'à "+start.address+",\r\nprendre le vélo pendant "+result3["rows"][0]["elements"][0]["distance"]["text"].ToString()+" jusqu'à "+end.address+",\r\npuis marcher pendant "+ result2["rows"][0]["elements"][0]["distance"]["text"].ToString()+" jusqu'à " +destination+" (Arrivée).";
            String elevationResult = SendRequest("https://maps.googleapis.com/maps/api/elevation/json?path=" + start.getPositionString() + "|" + end.getPositionString() + "&samples=20&key=" + apiKey);
            SetElevation(elevationResult);
            return route;   
        }

        public Station NearestStation(String position)
        {
            String destinations = "";
            foreach(Station station in stations)
            {
                destinations += station.getPositionString() + "|";
            }
            System.Diagnostics.Debug.WriteLine(destinations);
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
                String unit = distance.Split(' ')[1];
                dist = dist.Replace(",", "");
                dist = dist.Replace(".", ",");
                Double distNum = Convert.ToDouble(dist);
                if (String.Equals(unit, "km"))
                    distNum = distNum * 1000;
                if ((min < 0 || distNum < min) && Convert.ToInt32(stations[i].totalStands["availabilities"]["bikes"]) > 0)
                {
                    min = distNum;
                    minDist = distance;
                    minDur = duration;
                    minIndex = i;
                }
            }
            nearest = stations[minIndex];
            return nearest;
        }

        private void SetElevation(String response)
        {
            System.Diagnostics.Debug.WriteLine(response);
            dynamic obj = JsonConvert.DeserializeObject(response);
            
            foreach (var e in obj.results)
            {
                this.elevation.Add(e.elevation.ToString());
            }
        }

        public List<String> GetElevation()
        {
            return this.elevation;
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

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
    public class Data
    {
        private List<String> cities;
        private String city;
        private String stations;
        private Timer aTimer;



        public Data()
        {
            cities = new List<String>();
            String responseFromServer = SendRequest("https://api.jcdecaux.com/vls/v3/contracts?apiKey=92f94affefba484f0cf2d1c44d26582943d7cee8");
            dynamic array = JsonConvert.DeserializeObject(responseFromServer);
            SetCities(array);
            SetTimer();
        }

        public void SetCities(dynamic array)
        {
            foreach (var obj in array)
            {
                cities.Add(obj.name.ToString());
            }
        }

        public List<String> GetCities()
        {
            return cities;
        }

        public void SetCity(String city)
        {
            this.city = city;
            UpdateStations(city);
        }

        public void UpdateStations(String city)
        {
            stations = SendRequest("https://api.jcdecaux.com/vls/v3/stations?contract=" + city + "&apiKey=92f94affefba484f0cf2d1c44d26582943d7cee8");
        }

        public void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new Timer(60000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if(city != null)
                UpdateStations(city);
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

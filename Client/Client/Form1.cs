using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace Client
{
    using RouteService;
    public partial class Form1 : Form
    {
        RouteServiceClient client;
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            client = new RouteServiceClient();
            client.InitCache();
            String[] cities = client.GetCities();
            foreach(var obj in cities)
            {
                selectCity.Items.Add(obj);
            }
        }

        private void selectCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            //client.InitCity(selectCity.SelectedItem.ToString());
        }

        private void searchRoute_Click(object sender, EventArgs e)
        {
            String originAddress = origin.Text;
            String destinationAddress = destination.Text;
            System.Diagnostics.Debug.WriteLine(originAddress + " " + destinationAddress);
            //if(!(String.Equals(originAddress, "Entrez une adresse de départ") && String.Equals(originAddress, "Entrez une adresse de destination")))
                
        }
    }
}

using System;
using System.Windows.Forms;


namespace Client
{
    using GMap.NET.MapProviders;
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
            client.InitCity(selectCity.SelectedItem.ToString());
        }

        private void searchRoute_Click(object sender, EventArgs e)
        {
            String originAddress = origin.Text;
            String destinationAddress = destination.Text;
            //System.Diagnostics.Debug.WriteLine(originAddress + " " + destinationAddress);
            if (!(String.Equals(originAddress, "Entrez une adresse de départ") && String.Equals(originAddress, "Entrez une adresse de destination")))
                result.Text = client.SearchRoute(originAddress, destinationAddress);
                    //System.Diagnostics.Debug.WriteLine(client.SearchRoute(originAddress, destinationAddress));
        }


        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }
    }
}

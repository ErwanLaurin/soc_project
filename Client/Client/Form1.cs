using System;
using System.Windows.Forms;


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
            client.InitCity(selectCity.SelectedItem.ToString());
        }

        private void searchRoute_Click(object sender, EventArgs e)
        {
            String originAddress = origin.Text;
            String destinationAddress = destination.Text;
            //System.Diagnostics.Debug.WriteLine(selectCity.SelectedItem.ToString());
            if (!(selectCity.SelectedItem == null || String.Equals(originAddress, "") || String.Equals(destinationAddress, "")))
            {
                result.Text = client.SearchRoute(originAddress, destinationAddress);
                String[] elevationResult = client.GetElevation();
                //System.Diagnostics.Debug.WriteLine(elevationResult[0]);
                int i = 0;
                foreach(var val in elevationResult)
                {
                    elevation.Series[0].Points.AddXY(i, val.Replace(",", "."));
                    i++;
                }
            }

            //System.Diagnostics.Debug.WriteLine(client.SearchRoute(originAddress, destinationAddress));
        }


        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void elevation_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void origin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

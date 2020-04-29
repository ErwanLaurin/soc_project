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
    using CacheService;
    public partial class Form1 : Form
    {
        CacheServiceClient client;
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            client = new CacheServiceClient();
            client.InitCache();
            string[] cities = client.GetCities();
            foreach(var obj in cities)
            {
                selectCity.Items.Add(obj);
            }
        }

        private void selectCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            client.InitCity(selectCity.SelectedItem.ToString());
        }
    }
}

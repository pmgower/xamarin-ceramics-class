using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ApiCreationAndConsumptionApps.Models;
using Newtonsoft.Json;
using RestSharp;
using Xamarin.Forms;

namespace ApiCreationAndConsumptionApps
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Monkey> Monkeys { get; private set; } = new ObservableCollection<Monkey>();
        public bool IsRefreshing { get; private set; } = false;
        
        public MainPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        private void RefreshView_OnRefreshing(object sender, EventArgs e) => RefreshData();

        private void RefreshData()
        {
            IsRefreshing = true;
            
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => true;

            var API_URL = "https://localhost:5001/monkeys";
            var client = new RestClient(API_URL)
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);

            List<Monkey> remoteMonkeys = JsonConvert.DeserializeObject<List<Monkey>>(response.Content);
            Monkeys.Clear();
            
            remoteMonkeys.ForEach(monkey => Monkeys.Add(monkey));

            IsRefreshing = false;
        }
    }
}
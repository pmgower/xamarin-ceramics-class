using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CounterApp
{
    public partial class MainPage : ContentPage
    {
        private readonly Container container = new Container();

        public MainPage()
        {
            InitializeComponent();
        }

        private void IncreaseCount_OnClicked(object sender, EventArgs e)
        {
            container.Count++;
        }

        private void SeeResults_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ResultsPage(container));
        }
    }
}
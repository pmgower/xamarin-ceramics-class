using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CounterApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsPage : ContentPage
    {
        private Container _container;
        
        public ResultsPage(Container container)
        {
            InitializeComponent();
            _container = container;
            countLabel.Text = _container.Count.ToString();
        }

        private void ResetCount_OnClicked(object sender, EventArgs e)
        {
            _container.Count = 0;
            countLabel.Text = _container.Count.ToString();
        }
    }
}
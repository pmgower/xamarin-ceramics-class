using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetirementApp.ViewModels;
using Xamarin.Forms;

namespace RetirementApp
{
    public partial class MainPage : ContentPage
    {
        public readonly CalculatorViewModel calculatorViewModel;
        
        public MainPage(CalculatorViewModel calculatorViewModel)
        {
            InitializeComponent();
            this.calculatorViewModel = calculatorViewModel;
            BindingContext = calculatorViewModel;
        }

        private void ViewDetails(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DetailsPage(calculatorViewModel));
        }
    }
}
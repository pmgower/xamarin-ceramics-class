using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetirementApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RetirementApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        public readonly CalculatorViewModel calculatorViewModel;

        public DetailsPage(CalculatorViewModel calculatorViewModel)
        {
            InitializeComponent();
            
            this.calculatorViewModel = calculatorViewModel;
            BindingContext = calculatorViewModel;
        }

        private void AccountSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedAccount = e.CurrentSelection[0] as AccountViewModel;
            Navigation.PushAsync(new AccountDetails(selectedAccount));
        }
    }
}
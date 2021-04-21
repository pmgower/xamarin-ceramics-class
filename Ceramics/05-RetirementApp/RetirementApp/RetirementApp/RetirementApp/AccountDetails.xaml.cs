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
    public partial class AccountDetails : ContentPage
    {
        public readonly AccountViewModel accountViewModel;
        
        public AccountDetails(AccountViewModel accountViewModel)
        {
            InitializeComponent();

            this.accountViewModel = accountViewModel;
            BindingContext = accountViewModel;
        }
    }
}
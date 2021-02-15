using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatApp.Models;
using Xamarin.Forms;

namespace CatApp
{
    public partial class MainPage : ContentPage
    {
        private App myApp;
        
        public MainPage()
        {
            InitializeComponent();
            myApp = App.Current as App;
            BindingContext = myApp.MyAppModel;
        }

        private void MyCatList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            myApp.MyAppModel.RemoveCat(e.SelectedItem as Cat);
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            myApp.MyAppModel.AddCat();
        }
    }
}
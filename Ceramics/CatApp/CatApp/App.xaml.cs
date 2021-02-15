using System;
using CatApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace CatApp
{
    public partial class App : Application
    {
        public AppModel MyAppModel { get; set; }

        public App()
        {
            InitializeComponent();
            MyAppModel = new AppModel();
            MainPage = new MainPage();
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
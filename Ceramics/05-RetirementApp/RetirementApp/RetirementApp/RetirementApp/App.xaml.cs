using System;
using System.Collections.Generic;
using RetirementApp.Models;
using RetirementApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace RetirementApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            List<Account> accounts = new List<Account>()
            {
                new Account("Checking 1", 1500m, .051m, 100m),
                new Account("Checking 2", 2500m, .052m, 200m),
                new Account("Checking 3", 3500m, .053m, 300m),
                new Account("Checking 4", 4500m, .054m, 400m)
            };
            
            var calculator = new Calculator(accounts);

            var calculatorViewModel = new CalculatorViewModel(calculator);

            MainPage = new NavigationPage(new MainPage(calculatorViewModel));
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
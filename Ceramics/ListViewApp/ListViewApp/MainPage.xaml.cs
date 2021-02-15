using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var contacts = new List<Contact>()
            {
                new Contact()
                {
                    Name = "Umair",
                    Number = "0456445450945",
                    ImageUrl = "http://placeimg.com/200/200/people"
                },
                new Contact()
                {
                    Name = "Cat",
                    Number = "034456445905",
                    ImageUrl = "http://placekitten.com/200/200"
                },
                new Contact()
                {
                    Name = "Nature",
                    Number = "56445905",
                    ImageUrl = "http://placeimg.com/200/200/nature"
                }
            };
            ContactListView.ItemsSource = contacts;
            
        }
    }
}
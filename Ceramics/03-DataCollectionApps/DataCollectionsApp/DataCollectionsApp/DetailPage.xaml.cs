using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataCollectionsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage(string title, ObservableCollection<DeskItem> itemContainedItems)
        {
            InitializeComponent();

            DetailTitle.Text = title;
            DetailListView.ItemCollection.ItemsSource = itemContainedItems;
        }
    }
}
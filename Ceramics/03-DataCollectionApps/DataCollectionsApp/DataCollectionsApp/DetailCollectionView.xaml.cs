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
    public partial class DetailCollectionView : ContentView
    {
        private ObservableCollection<DeskItem> deskItems = DeskItem.DefaultDeskItemObservableCollection;

        public DetailCollectionView()
        {
            InitializeComponent();

            ItemCollection.ItemsSource = deskItems;
        }

        private void ItemCollection_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = e.CurrentSelection.FirstOrDefault() as DeskItem;
            if (item.ContainedItems.Count > 0)
            {
                Navigation.PushAsync(new DetailPage(item.Name, item.ContainedItems));
            }
        }
    }
}
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
    public partial class DetailCarouselView : ContentView
    {
        private ObservableCollection<DeskItem> deskItems = DeskItem.DefaultDeskItemObservableCollection;

        public DetailCarouselView()
        {
            InitializeComponent();
        }

        private void ItemCollection_OnCurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            var item = e.CurrentItem as DeskItem;
            if (item.ContainedItems.Count > 0)
            {
                Navigation.PushAsync(new DetailPage(item.ContainedItems));
            }
        }
    }
}
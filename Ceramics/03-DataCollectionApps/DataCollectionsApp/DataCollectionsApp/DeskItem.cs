using System.Collections.ObjectModel;

namespace DataCollectionsApp
{
    public class DeskItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public ObservableCollection<DeskItem> ContainedItems { get; set; } = new ObservableCollection<DeskItem>();

        public static ObservableCollection<DeskItem> DefaultDeskItemObservableCollection
        {
            get
            {

                var defaultDeskItems = new ObservableCollection<DeskItem>()
                {
                    new DeskItem()
                    {
                        Name = "Notepad",
                        Description = "Something to write on",
                        // random image url - https://source.unsplash.com/150x250/?notebook
                        // ImageUrl = "https://images.unsplash.com/photo-1610088660962-3f85d27cadc7?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=250&ixid=MXwxfDB8MXxyYW5kb218fHx8fHx8fA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=150"
                        ImageUrl = "https://images.unsplash.com/photo-1610088660962-3f85d27cadc7?h=150&w=150&crop=entropy&cs=tinysrgb&fit=crop&fm=jpg"
                    },
                    new DeskItem()
                    {
                        Name = "Pencil",
                        Description = "Something to write with",
                        // random image url - https://source.unsplash.com/150x250/?pencil
                        ImageUrl = "https://images.unsplash.com/photo-1611576671487-69edace05802?h=150&w=150&crop=entropy&cs=tinysrgb&fit=crop&fm=jpg"
                    },
                    new DeskItem()
                    {
                        Name = "Coffee Mug",
                        Description = "Only way to start the morning",
                        // random image url - https://source.unsplash.com/150x250/?coffee%20mug
                        ImageUrl = "https://images.unsplash.com/photo-1582529025473-d826a9c0c7f2?h=150&w=150&crop=entropy&cs=tinysrgb&fit=crop&fm=jpg",
                        ContainedItems = new ObservableCollection<DeskItem>()
                        {
                            new DeskItem()
                            {
                                Name = "Water",
                                Description = "A good liquid to add",
                                // random image url - https://source.unsplash.com/150x250/?water
                                ImageUrl = "https://images.unsplash.com/photo-1613536869939-6f8c354085cc?h=150&w=150&crop=entropy&cs=tinysrgb&fit=crop&fm=jpg"
                            },
                            new DeskItem()
                            {
                                Name = "Coffee Beans",
                                Description = "Crucial ingredient for coffee",
                                // random image url - https://source.unsplash.com/150x250/?coffeebeans
                                ImageUrl = "https://images.unsplash.com/photo-1554646533-de2d01895a23?h=150&w=150&crop=entropy&cs=tinysrgb&fit=crop&fm=jpg"
                            }
                        }

                    }
                };
                return defaultDeskItems;
            }
        }
    }
}
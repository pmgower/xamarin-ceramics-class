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
                        ImageUrl = ""
                    },
                    new DeskItem()
                    {
                        Name = "Pencil",
                        Description = "Something to write with",
                        ImageUrl = ""
                    },
                    new DeskItem()
                    {
                        Name = "Coffee Mug",
                        Description = "Only way to start the morning",
                        ImageUrl = "",
                        ContainedItems = new ObservableCollection<DeskItem>()
                        {
                            new DeskItem()
                            {
                                Name = "Water",
                                Description = "A good liquid to add",
                                ImageUrl = ""
                            }
                        }

                    }
                };
                return defaultDeskItems;
            }
        }
    }
}
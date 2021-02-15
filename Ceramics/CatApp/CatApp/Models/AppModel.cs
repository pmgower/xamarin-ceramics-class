using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CatApp.Models
{
    public class AppModel
    {
        public ObservableCollection<Cat> Cats { get; set; } = new ObservableCollection<Cat>()
        {
            new Cat()
            {
                Name = "Cat 1",
                Description = "My cat's description goes here",
                ImageUrl = "https://placekitten.com/200/200"
            },
            new Cat()
            {
                Name = "Cat 1",
                Description = "My cat's another description goes here",
                ImageUrl = "https://placekitten.com/200/200"
            },
            new Cat()
            {
                Name = "Cat 3",
                Description = "My cat's other description goes here",
                ImageUrl = "https://placekitten.com/200/200"
            }
        };

        public void AddCat()
        {
            Cats.Add(new Cat() { Name="Cat 4", Description = "Some description here", ImageUrl = "https://placekitten.com/200/200" });
        }

        public void RemoveCat(Cat catToRemove)
        {
            Cats.Remove(catToRemove);
        }
    }
}
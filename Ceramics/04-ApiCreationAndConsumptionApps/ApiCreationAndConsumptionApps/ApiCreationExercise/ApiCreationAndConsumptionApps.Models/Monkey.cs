using System;
using System.Collections.Generic;

namespace ApiCreationAndConsumptionApps.Models
{
    public class Monkey
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        
        public static readonly List<Monkey> DefaultMonkeyList = new List<Monkey>()
        {
            new Monkey()
            {
                Name = "Edgar",
                Description = "He has orange and black fur and a black tail",
                // https://source.unsplash.com/250x250/?monkey
                ImageUrl = "https://images.unsplash.com/photo-1610227369190-5f6b2ebfec59?w=250&h=250&crop=entropy&cs=tinysrgb&fit=crop&fm=jpg"
            },
            new Monkey()
            {
                Name = "Sam",
                Description = "She has grey fur and a white tail",
                ImageUrl = "https://images.unsplash.com/photo-1608825089053-f060747ecd3b?w=250&h=250&crop=entropy&cs=tinysrgb&fit=crop&fm=jpg"
            },
            new Monkey()
            {
                Name = "Johnny",
                Description = "He has brown and white fur and a brown tail",
                ImageUrl = "https://images.unsplash.com/photo-1611153854632-2422bbf0884b?w=250&h=250&crop=entropy&cs=tinysrgb&fit=crop&fm=jpg"
            },
            new Monkey()
            {
                Name = "Kevin",
                Description = "He has orange and brown fur and a black tail",
                ImageUrl = "https://images.unsplash.com/photo-1611539222172-0f7e76279dd5?w=250&h=250&crop=entropy&cs=tinysrgb&fit=crop&fm=jpg"
            },
        };
    }
}
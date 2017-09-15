using MVCInternetGamesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCInternetGamesShop.ViewModels
{
    public class GameFormViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageName { get; set; }
        public IEnumerable<Platform> Platforms { get; set; }
        public List<byte> PlatformId { get; set; }
        public bool IsBestseller { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }        
        public List<Category> Category { get; set; }
        public List<byte> CategoryId { get; set; }
        public List<Category> CurrentCategories { get; set; }
        public List<Category> RemainsCategories { get; set; }
        public List<int> SelectedIds { get; set; }
        public string CurrentCategoriesNames { get; set; }


       



        public GameFormViewModel(Game game)
        {
            Id = game.Id;
            Name = game.Name;
            IsBestseller = game.IsBestseller;
            Price = game.Price;
            ImageName = game.ImageName;            
            ReleaseDate = game.ReleaseDate;
            Description = game.Description;
        }

        public GameFormViewModel()
        {
            Id = 0;
        }

        


    }
}
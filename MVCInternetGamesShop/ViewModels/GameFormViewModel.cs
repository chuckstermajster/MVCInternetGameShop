using MVCInternetGamesShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCInternetGamesShop.ViewModels
{
    public class GameFormViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa gry")]
        public string Name { get; set; }

        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        [Display(Name = "Nazwa obrazka")]
        public string ImageName { get; set; }

        public IEnumerable<Platform> Platforms { get; set; }

        [Display(Name = "Wybierz platformę")]
        public List<byte> PlatformId { get; set; }

        [Display(Name = "Bestseller?")]
        public bool IsBestseller { get; set; }

        public string PlatformName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data premiery")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Display(Name = "Kategoria")]
        public List<Category> Category { get; set; }


        public List<byte> CategoryId { get; set; }












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
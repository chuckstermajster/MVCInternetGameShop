using MVCInternetGamesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCInternetGamesShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Game> XBoxNewest { get; set; }
        public IEnumerable<Game> XBoxBestsellers { get; set; }
        public IEnumerable<Game> Ps4Newest { get; set; }
        public IEnumerable<Game> Ps4Bestsellers { get; set; }
        public IEnumerable<Game> PCNewest { get; set; }
        public IEnumerable<Game> PCBestsellers { get; set; }
    }
}
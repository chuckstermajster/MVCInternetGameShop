using MVCInternetGamesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCInternetGamesShop.ViewModels
{
    public class HomeViewModel
    {
        IEnumerable<Game> New { get; set; }
        IEnumerable<Game> Bestseller { get; set; }
    }
}
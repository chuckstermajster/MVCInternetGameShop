using MVCInternetGamesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCInternetGamesShop.ViewModels
{
    public class CartViewModel
    {
        public List<CartPosition> CartPosition { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
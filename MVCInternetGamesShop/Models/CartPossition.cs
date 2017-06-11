using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCInternetGamesShop.Models
{
    public class CartPossition
    {
        public Game Game { get; set; }
        public int Quantity { get; set; }
        public decimal PriceOfItem { get; set; }
    }
}
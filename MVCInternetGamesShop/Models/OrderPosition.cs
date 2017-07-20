using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCInternetGamesShop.Models
{
    public class OrderPosition
    {
        public int id { get; set; }
        public int OrderId { get; set; }
        public int GameId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual  Order Order { get; set; }
        public virtual Game Game { get; set; }
    }
}
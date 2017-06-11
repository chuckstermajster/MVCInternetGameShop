using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCInternetGamesShop.Models;

namespace MVCInternetGamesShop.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public Address Address { get; set; }

        public DateTime CreationTime { get; set; }

        public virtual ApplicationUser User { get; set; }

        

    }
}
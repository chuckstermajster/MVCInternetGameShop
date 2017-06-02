using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesShop.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public Address Address { get; set; }

        public virtual ApplicationUser User { get; set; }

        

    }
}
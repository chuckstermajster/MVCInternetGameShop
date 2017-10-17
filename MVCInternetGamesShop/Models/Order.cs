using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCInternetGamesShop.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCInternetGamesShop.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        

        public DateTime CreationTime { get; set; }

        public List<OrderPosition> OrderPositions { get; set; }

        public string  Name { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public string City { get; set; }


        public string Street { get; set; }


        public int? StreetNumber { get; set; }

        public int? HouseNumber { get; set; }


        public string PostCode { get; set; }

        public virtual ApplicationUser User { get; set; }

        

        

    }
}
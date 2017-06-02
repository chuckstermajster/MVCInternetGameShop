using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCInternetGamesShop.Models
{
    public class Address
    {
        
        public int Id { get; set; }


        [Required(ErrorMessage = "To pole jest wymagane")]
        public string City { get; set; }

        
        public string Street { get; set; }

        
        public int StreetNumber { get; set; }

        public int HouseNumber { get; set; }

        
        public string PostCode { get; set; }

        

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GamesShop.Models
{
    public class Address
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public string City { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Street { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public int StreetNumber { get; set; }

        public int HouseNumber { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public string PostCode { get; set; }

        

    }
}
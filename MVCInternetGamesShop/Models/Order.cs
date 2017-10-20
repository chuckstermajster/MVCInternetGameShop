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
        [Display(Name = "Imię")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string  Name { get; set; }

        [Display(Name = "Miasto")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string City { get; set; }

        [Display(Name = "Ulica")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Street { get; set; }

        [Display(Name = "Numer ulicy")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public int StreetNumber { get; set; }

        [Display(Name = "Numer lokalu")]
        public int? HouseNumber { get; set; }

        
        [Required(ErrorMessage = "To pole jest wymagane")]
        [Display(Name = "Kod pocztowy")]
        public string PostCode { get; set; }

        public decimal TotalValue { get; set; }

        public virtual ApplicationUser User { get; set; }

        

        

    }
}
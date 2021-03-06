﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCInternetGamesShop.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        //[Required(ErrorMessage = "Nazwa obrazka jest obowiązkowa. Jeśli nie chcesz dodawać obrazka - wpisz cokolwiek")]
        public string ImageName { get; set; }
        
        public Platform Platform { get; set; }
        public byte PlatformId { get; set; }
        public bool IsBestseller { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Podana wartość musi być datą w formacie dd.mm.yyyy")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReleaseDate { get; set; }
        public string Description { get; set; }

        public virtual ICollection<GameCategory> GameCategory { get; set; }


    }
}
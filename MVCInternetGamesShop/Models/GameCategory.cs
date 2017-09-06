using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCInternetGamesShop.Models
{
    public class GameCategory
    {
        [Key, Column(Order=0)]
        public int GameID { get; set; }
        [Key, Column(Order = 1)]
        public int CategoryID { get; set; }

        public virtual Game Game { get; set; }
        public virtual Category Category { get; set; }
    }
}
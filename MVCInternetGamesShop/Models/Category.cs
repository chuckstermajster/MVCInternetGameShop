using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCInternetGamesShop.Models
{
    public class Category
    {

       
        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GameCategory> GameCategory { get; set; }

    }
}
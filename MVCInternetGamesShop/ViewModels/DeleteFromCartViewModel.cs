using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCInternetGamesShop.ViewModels
{
    public class DeleteFromCartViewModel
    {
        public int CurrentPositionId { get; set; }
        public int CurrentPostionQuantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
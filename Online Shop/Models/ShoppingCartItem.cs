using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }

        public Products Product { get; set; }

        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }



    }
}

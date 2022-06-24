using Online_Shop.Areas.Identity.Data;
using Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.ViewModel
{
    public class SummeryVm
    {
        public SummeryVm()
        {
            CartItems = new List<Cart>();

        }
        public Online_ShopUser Online_ShopUser { get; set; }

        public IEnumerable<Cart> CartItems { get; set; }
    }
}

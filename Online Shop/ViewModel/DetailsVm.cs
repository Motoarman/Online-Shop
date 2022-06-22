using Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.ViewModel
{
    public class DetailsVm
    {
        public DetailsVm()
        {
           Products = new Products();
            
        }
        public Products Products { get; set; }
        public bool ExitsInCart { get; set; }
    }
}

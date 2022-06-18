using Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.Interfaces
{
    interface IProductRepo
    {
        IEnumerable<Products> Products { get; set; }

        Products GetProducts(int Id);
    }
}

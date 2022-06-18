using Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.Interfaces
{
    interface ICategories
    {
        IEnumerable<Categories> Categories { get; set; }
    }
}

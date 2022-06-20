using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.Models
{
    public class Cart
    {
        public int Id { get; set; }

        [NotMapped]
        public string Image { get; set; }
        public string Title { get; set; }

        public string Discription { get; set; }

        public int Quantity { get; set; }
        public int Amount { get; set; }

    }
}

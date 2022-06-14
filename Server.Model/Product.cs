using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Server.Model
{
    public partial class Product
    {
        public Product()
        {
            PurchaceItems = new HashSet<PurchaceItem>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }

        [DisplayName("Image name")]
        public string Image { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }

        public int? Price { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<PurchaceItem> PurchaceItems { get; set; }
    }
}

using Online_Shop.Areas.Identity.Data;
using Online_Shop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.Models
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? PurchaseItemId { get; set; }

        public string UserId { get; set; }
        public string Comment { get; set; }

        public virtual PurchaceItem PurchaseItem { get; set; }

      



    }
}


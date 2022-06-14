using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.Models
{
    public class PurchaceItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? Count { get; set; }

        public virtual Products Product { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}

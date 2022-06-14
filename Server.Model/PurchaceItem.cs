using System;
using System.Collections.Generic;

#nullable disable

namespace Server.Model
{
    public partial class PurchaceItem
    {
        public PurchaceItem()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? Count { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}

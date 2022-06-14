using System;
using System.Collections.Generic;

#nullable disable

namespace Server.Model
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? PurchaseItemId { get; set; }
        public string Comment { get; set; }

        public virtual PurchaceItem PurchaseItem { get; set; }
    }
}

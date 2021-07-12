using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class OrdersItem
    {
        public int OrderItemId { get; set; }
        public short? ProductId { get; set; }
        public int? OrderId { get; set; }
        public short? Quentity { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Product Product { get; set; }
    }
}

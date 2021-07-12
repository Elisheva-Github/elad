using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Orders
    {
        public Orders()
        {
            OrdersItem = new HashSet<OrdersItem>();
        }

        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? OrderSum { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrdersItem> OrdersItem { get; set; }
    }
}

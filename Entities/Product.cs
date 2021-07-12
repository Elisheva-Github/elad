using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Product
    {
        public Product()
        {
            OrdersItem = new HashSet<OrdersItem>();
        }

        public short ProductId { get; set; }
        public string ProductName { get; set; }
        public short? CategoryId { get; set; }
        public int? Price { get; set; }
        public string Descriptionn { get; set; }
        public string ImageName { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<OrdersItem> OrdersItem { get; set; }
    }
}

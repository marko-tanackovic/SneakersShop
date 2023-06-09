using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Domain.Entities
{
    public class ProductSize : Entity
    {
        public int ProductId { get; set; }
        public int SizeId { get; set; }

        public Product Product { get; set; }
        public Size Size { get; set; }

        public virtual ICollection<StoreProductSize> ProductSizeStores { get; set; } = new List<StoreProductSize>();
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}

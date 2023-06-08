using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Domain.Entities
{
    public class OrderItem : Entity
    {
        public int OrderId { get; set; }
        public int ProductSizeId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Order Order { get; set; }
        public ProductSize Product { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Domain.Entities
{
    public class StoreProductSize
    {
        public int ProductSizeId { get; set; }
        public int StoreId { get; set; }
        public int Quantity { get; set; }

        public ProductSize Product { get; set; }
        public Store Store { get; set; }
    }
}

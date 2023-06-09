using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCases.DTO
{
    public class CreateProductSizeDTO
    {
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public IEnumerable<ProductSizeStoreDTO> ProductStores { get; set; }
    }
    
    public class ProductSizeStoreDTO
    {
        public int StoreId { get; set; }
        public int Quantity { get; set; }
    }
}

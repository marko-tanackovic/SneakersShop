using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCases.DTO
{
    public class UpdateProductSizeStoreDTO : UpdateEntityDTO
    {
        public int StoreId { get; set; }
        public int Quantity { get; set; }
    }
}

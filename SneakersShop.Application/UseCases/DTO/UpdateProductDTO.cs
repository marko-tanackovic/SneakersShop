using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCases.DTO
{
    public class UpdateProductDTO : UpdateEntityDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int? BrandId { get; set; }
        public int? Discount { get; set; }
        public decimal? Price { get; set; }
        public string Image { get; set; }
        public IEnumerable<string> Colors { get; set; } = new List<string>();
    }
}

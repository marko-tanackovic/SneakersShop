using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int BrandId { get; set; }
        public int ImageId { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }

        public Brand Brand { get; set; }
        public File Image { get; set; }
        public virtual ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Domain.Entities
{
    public class Color : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<ProductColor> ColorProducts { get; set; } = new List<ProductColor>();
    }
}

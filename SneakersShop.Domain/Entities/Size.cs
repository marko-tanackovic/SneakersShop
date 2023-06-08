using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Domain.Entities
{
    public class Size : Entity
    {
        public decimal Number { get; set; }
        public string Detail { get; set; }
        public int SizeCategoryId { get; set; }

        public SizeCategory SizeCategory { get; set; }
        public virtual ICollection<ProductSize> SizeProducts { get; set; } = new List<ProductSize>();
    }
}

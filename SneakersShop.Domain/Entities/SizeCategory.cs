using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Domain.Entities
{
    public class SizeCategory : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Size> Sizes { get; set; } = new List<Size>();
    }
}

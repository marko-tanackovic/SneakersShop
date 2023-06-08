using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Domain.Entities
{
    public class Store : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public string Phone { get; set; }

        public City City { get; set; }
        public virtual ICollection<StoreProductSize> StoreProducts { get; set; } = new List<StoreProductSize>();
    }
}

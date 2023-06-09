using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Domain.Entities
{
    public class City : Entity
    {
        public string Name { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Store> Stores { get; set; } = new List<Store>();
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}

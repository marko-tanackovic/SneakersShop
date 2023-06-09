using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Domain.Entities
{
    public enum OrderStatus
    {
        Pending = 1,
        Shipped = 2,
        Completed = 3,
        Cancelled = 4
    }
}

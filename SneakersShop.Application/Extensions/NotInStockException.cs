using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.Extensions
{
    public class NotInStockException : Exception
    {
        public NotInStockException(int id, string store)
            : base($"There are no products with {id} in {store}")
        {

        }
    }
}

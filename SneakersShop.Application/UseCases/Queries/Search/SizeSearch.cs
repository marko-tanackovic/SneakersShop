using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCases.Queries.Search
{
    public class SizeSearch
    {
        public decimal? SizeFrom { get; set; }
        public decimal? SizeTo { get; set; }
    }
}

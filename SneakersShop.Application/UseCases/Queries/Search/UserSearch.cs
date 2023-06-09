using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCases.Queries.Search
{
    public class UserSearch : KeywordSearch
    {
        public bool? HasReviews { get; set; }
        public int? Orders { get; set; }
    }
}

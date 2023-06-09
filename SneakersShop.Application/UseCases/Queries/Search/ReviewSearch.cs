using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCases.Queries.Search
{
    public class ReviewSearch : KeywordSearch
    {
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
        public bool? HasChildren { get; set; }
    }
}

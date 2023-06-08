using SneakersShop.Application.UseCases.DTO;
using SneakersShop.Application.UseCases.Queries.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCases.Queries
{
    public interface IGetSizesQuery : IQuery<SizeSearch, IEnumerable<SizeDTO>>
    {
    }
}

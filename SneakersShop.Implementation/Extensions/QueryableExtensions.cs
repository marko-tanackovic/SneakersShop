using SneakersShop.Application.UseCases.DTO;
using SneakersShop.Application.UseCases.Queries.Search;
using SneakersShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Implementation.Extensions
{
    public static class QueryableExtensions
    {
        public static PaginationResponse<TDto> ToPagedResponse<TEntity, TDto>(
            this IQueryable<TEntity> query,
            PaginationSearch search,
            Expression<Func<TEntity, TDto>> conversion)
            where TDto : class
            where TEntity : Entity

        {
            if (search.PerPage <= 0)
            {
                search.PerPage = 10;
            }

            if (search.Page <= 0)
            {
                search.Page = 1;
            }

            var skip = (search.Page - 1) * search.PerPage;

            return new PaginationResponse<TDto>
            {
                TotalCount = query.Count(),
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                Items = query.Skip(skip)
                             .Take(search.PerPage)
                             .Select(conversion)
                             .ToList()
            };
        }
    }
}

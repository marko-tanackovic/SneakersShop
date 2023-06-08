using Microsoft.EntityFrameworkCore;
using SneakersShop.Application.UseCases.DTO;
using SneakersShop.Application.UseCases.Queries;
using SneakersShop.Application.UseCases.Queries.Search;
using SneakersShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Implementation.UseCases.Queries
{
    public class EfSearchLogEntriesQuery : EfUseCase, ISearchLogEntriesQuery
    {
        public EfSearchLogEntriesQuery(SneakersShopContext context) : base(context)
        {
        }

        public int Id => 53;

        public string Name => "Search Log Entries";

        public string Description => "Search log entries with userId, caseName, dateTo and dateFrom";

        public IEnumerable<LogEntryDTO> Execute(LogEntrySearch search)
        {
            var query = Context.LogEntries.AsQueryable();

            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.ActorId == search.UserId.Value);
            }

            if (!string.IsNullOrEmpty(search.CaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.CaseName));
            }

            if (search.DateFrom.HasValue)
            {
                query = query.Where(x => x.CreatedAt >= search.DateFrom.Value);
            }

            if (search.DateTo.HasValue)
            {
                query = query.Where(x => x.CreatedAt <= search.DateTo.Value);
            }

            var logs = query.Select(x => new LogEntryDTO
            {
                Username = x.Actor,
                UseCaseName = x.UseCaseName,
                UseCaseData = x.UseCaseData,
                CreatedAt = x.CreatedAt
            }).ToList();

            return logs;
        }
    }
}

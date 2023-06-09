using Newtonsoft.Json;
using SneakersShop.Application.Logging;
using SneakersShop.DataAccess;
using SneakersShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Implementation.Logging
{
    public class EfUseCaseLogger : IUseCaseLogger
    {
        private readonly SneakersShopContext _context;

        public EfUseCaseLogger(SneakersShopContext context)
        {
            _context = context;
        }

        public void Add(UseCaseLogEntry entry)
        {
            _context.LogEntries.Add(new LogEntry
            {
                Actor = entry.Actor,
                ActorId = entry.ActorId,
                UseCaseData = JsonConvert.SerializeObject(entry.Data),
                UseCaseName = entry.UseCaseName,
                CreatedAt = DateTime.UtcNow
            });

            _context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCases.DTO
{
    public class LogEntryDTO
    {
        public string Username { get; set; }
        public string UseCaseName { get; set; }
        public string UseCaseData { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

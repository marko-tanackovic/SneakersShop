using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCases.DTO
{
    public class SizeCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<decimal> Sizes { get; set; } = new List<decimal>();
    }
}

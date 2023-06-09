using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCases.DTO
{
    public class SizeDTO
    {
        public int Id { get; set; }
        public decimal Number { get; set; }
        public string Detail { get; set; }
        public string SizeCategory { get; set; }
    }
}

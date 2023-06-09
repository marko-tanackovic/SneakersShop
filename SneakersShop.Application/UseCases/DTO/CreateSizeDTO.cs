using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCases.DTO
{
    public class CreateSizeDTO
    {
        public decimal Number { get; set; }
        public string Detail { get; set; }
        public int SizeCategoryId { get; set; }
    }
}

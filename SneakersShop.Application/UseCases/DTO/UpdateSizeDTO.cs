using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCases.DTO
{
    public class UpdateSizeDTO : UpdateEntityDTO
    {
        public decimal? Number { get; set; }
        public string Detail { get; set; }
    }
}

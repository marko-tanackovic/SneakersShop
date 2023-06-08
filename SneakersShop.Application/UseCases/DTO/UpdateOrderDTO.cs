using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCases.DTO
{
    public class UpdateOrderDTO : UpdateEntityDTO
    {
        public DateTime? ReceivedDate { get; set; }
        public string Status { get; set; }
    }
}

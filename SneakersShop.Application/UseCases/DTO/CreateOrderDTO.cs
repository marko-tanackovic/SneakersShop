using SneakersShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCases.DTO
{
    public class CreateOrderDTO
    {
        public int StoreId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime PromisedDate { get; set; }
        public string Payment { get; set; }
        public IEnumerable<CreateOrderItemDTO> OrderItems { get; set; }
    }
    public class CreateOrderItemDTO 
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

}

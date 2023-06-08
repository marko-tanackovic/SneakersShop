using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCases.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string User { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string Status { get; set; }
        public string Payment { get; set; }
        public string Store { get; set; }
        public IEnumerable<OrderItemDTO> OrderItems { get; set; }
    }
    public class OrderItemDTO
    {
        public string Name { get; set; }
        public decimal Size { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}

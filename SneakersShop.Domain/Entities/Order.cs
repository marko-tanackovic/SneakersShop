using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Domain.Entities
{
    public class Order : Entity
    {
        public int UserId { get; set; }
        public int StoreId { get; set; }
        public decimal Total { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? PromisedDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public OrderStatus Status { get; set; }
        public string Notes { get; set; }

        public User User { get; set; }
        public Store Store { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}

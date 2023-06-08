using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCases.DTO
{
    public class StoreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string ZipCode { get; set; }
        public IEnumerable<StoreProductDTO> StoreProducts { get; set; } = new List<StoreProductDTO>();
    }
    public class StoreProductDTO
    {
        public string Name { get; set; }
        public decimal Size { get; set; }
        public int Quantity { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCases.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Code { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public IEnumerable<string> Colors { get; set; }
        public IEnumerable<ReviewProductDTO> Reviews { get; set; }
        public IEnumerable<ProductSizeDTO> Sizes { get; set; }
    }
    public class ReviewProductDTO
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Text { get; set; }
        public int? Stars { get; set; }
        public DateTime CommentedAt { get; set; }
        public IEnumerable<ReviewProductDTO> ChildReviews { get; set; }
    }

    public class ProductSizeDTO
    {
        public decimal Size { get; set; }
        public IEnumerable<StoreSizeDTO> StoreSizes { get; set; } = new List<StoreSizeDTO>();
    }

    public class StoreSizeDTO
    {
        public string Store { get; set; }
        public int Quantity { get; set; }
    }
}

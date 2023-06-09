using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCases.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Text { get; set; }
        public string Product { get; set; }
        public int Stars { get; set; }
        public DateTime CommentedAt { get; set; }
        public IEnumerable<ChildReviewDTO> ChildReviews { get; set; } = new List<ChildReviewDTO>();
    }

    public class ChildReviewDTO
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Text { get; set; }
        public DateTime CommentedAt { get; set; }
        public IEnumerable<ChildReviewDTO> ChildReviews { get; set; } = new List<ChildReviewDTO>();

    }
}

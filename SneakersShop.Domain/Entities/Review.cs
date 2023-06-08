using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Domain.Entities
{
    public class Review : Entity
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Text { get; set; }
        public int? Stars { get; set; }
        public int? ParentReviewId { get; set; }

        public User User { get; set; }
        public Product Product { get; set; }
        public Review ParentReview { get; set; }
        public virtual ICollection<Review> ChildReviews { get; set; } = new List<Review>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCases.DTO
{
    public class CreateReviewDTO
    {
        public int? ProductId { get; set; }
        public int? ParentReviewId { get; set; }
        public int? Stars { get; set; }
        public string Text { get; set; }
    }
}

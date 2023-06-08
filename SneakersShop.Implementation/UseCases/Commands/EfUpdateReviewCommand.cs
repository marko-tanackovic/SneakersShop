using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SneakersShop.Application.Extensions;
using SneakersShop.Application.UseCases.Commands;
using SneakersShop.Application.UseCases.DTO;
using SneakersShop.DataAccess;
using SneakersShop.Domain.Entities;
using SneakersShop.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Implementation.UseCases.Commands
{
    public class EfUpdateReviewCommand : EfUseCase, IUpdateReviewCommand
    {
        private readonly UpdateReviewValidator _validator;
        public EfUpdateReviewCommand(SneakersShopContext context,
                                     UpdateReviewValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 40;

        public string Name => "Update Review";

        public string Description => "Update review text and stars";

        public void Execute(UpdateReviewDTO request)
        {
            var review = Context.Reviews.FirstOrDefault(x => x.Id == request.Id);

            _validator.ValidateAndThrow(request);

            if (review == null || !review.IsActive || review.DeletedAt.HasValue)
            {
                throw new EntityNotFoundException(request.Id, nameof(Review));
            }

            if (request.Stars.HasValue)
            {
                review.Stars = request.Stars.Value;
            }

            review.Text = request.Text;
            review.ModifiedAt = DateTime.UtcNow;
            Context.Entry(review).State = EntityState.Modified;

            Context.SaveChanges();
        }
    }
}

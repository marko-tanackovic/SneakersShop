using FluentValidation;
using SneakersShop.Application;
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
    public class EfCreateReviewCommand : EfUseCase, ICreateReviewCommand
    {
        private readonly CreateReviewValidator _validator;
        private readonly IApplicationActor _actor;
        public EfCreateReviewCommand(SneakersShopContext context, 
                                     CreateReviewValidator validator,
                                     IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 39;

        public string Name => "Create Review";

        public string Description => "Create Review using validators";

        public void Execute(CreateReviewDTO request)
        {
            _validator.ValidateAndThrow(request);

            int productId = request.ProductId.GetValueOrDefault();
            int stars = request.Stars.GetValueOrDefault();


            if (request.ParentReviewId.HasValue)
            {
                var parentReview = Context.Reviews.Find(request.ParentReviewId.Value);
                productId = parentReview.ProductId;
            }

            var newReview = new Review
            {
                ProductId = productId,
                Stars = stars,
                UserId = _actor.Id,
                ParentReviewId = request.ParentReviewId,
                Text = request.Text
            };

            Context.Reviews.Add(newReview);

            Context.SaveChanges();
        }
    }
}

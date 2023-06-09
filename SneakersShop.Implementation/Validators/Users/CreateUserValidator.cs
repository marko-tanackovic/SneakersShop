using FluentValidation;
using SneakersShop.Application.Uploads;
using SneakersShop.Application.UseCases.DTO;
using SneakersShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Implementation.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUserValidator(SneakersShopContext context, IBase64FileUploader uploader)
        {
            RuleFor(x => x.Email).NotEmpty()
                                 .WithMessage("Email is required")
                                 .EmailAddress()
                                 .WithMessage("Invalid email format")
                                 .Must(x => !context.Users.Any(u => u.Email == x))
                                 .WithMessage("Email already in use");

            RuleFor(x => x.FirstName).NotEmpty()
                                     .WithMessage("First Name is required");

            RuleFor(x => x.LastName).NotEmpty()
                                    .WithMessage("First Name is required");

            RuleFor(x => x.Username).NotEmpty()
                                    .WithMessage("Username is required")
                                    .Matches("^(?=[a-zA-Z0-9._]{4,20}$)(?!.*[_.]{2})[^_.].*[^_.]$")
                                    .WithMessage("Username invalid format - 4 min, 20 max, letters, numbers nad special characters(.,_)")
                                    .Must(x => !context.Users.Any(u => u.Username == x))
                                    .WithMessage("Username is already in use");

            RuleFor(x => x.Address).NotEmpty()
                                   .WithMessage("Address is required");

            RuleFor(x => x.Phone).NotEmpty()
                                 .WithMessage("Phone is required")
                                 .Matches("^(06)[0-9]{7,8}$")
                                 .WithMessage("Phone invalid format");

            RuleFor(x => x.Password).NotEmpty()
                                    .WithMessage("Password is required")
                                    .Matches("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{4,}$")
                                    .WithMessage("Password invalid format - 4 min letters and numbers only");


            When(x => x.BirthDate != null, () =>
            {
                RuleFor(x => x.BirthDate).NotEmpty()
                                         .WithMessage("Birth Date is required")
                                         .Must(x => x < DateTime.UtcNow)
                                         .WithMessage("Birth Date invalid format");
            });

            RuleFor(x => x.CityId).NotEmpty()
                                  .WithMessage("City is required")
                                  .Must(x => context.Cities.Any(c => c.Id == x))
                                  .WithMessage("City doesn't exist");

            When(x => x.Image != null, () =>
            {
                RuleFor(x => x.Image).Must(x => uploader.IsExtensionValid(x) &&
                                                       new List<string> { "jpg", "png", "jpeg" }.Contains(uploader.GetExtension(x)))
                                     .WithMessage("Invalid file extesion. Allowed are .jpg, .png and .jpeg");
            });
            
        }
    }
}

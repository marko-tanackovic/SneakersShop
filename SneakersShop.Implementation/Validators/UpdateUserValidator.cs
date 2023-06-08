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
    public class UpdateUserValidator : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserValidator(SneakersShopContext context, IBase64FileUploader uploader)
        {
            When(x => x.Image != null, () =>
            {
                RuleFor(x => x.Image).Must(x => uploader.IsExtensionValid(x) &&
                                                       new List<string> { "jpg", "png", "jpeg" }.Contains(uploader.GetExtension(x)))
                                     .WithMessage("Invalid file extesion. Allowed are .jpg, .png and .jpeg");
            });

            When(x => x.Password != null, () =>
            {
                RuleFor(x => x.Password).Matches("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{4,}$")
                                        .WithMessage("Password invalid format - 4 min letters and numbers only");
            });

            RuleFor(x => x.Username).Matches("^(?=[a-zA-Z0-9._]{4,20}$)(?!.*[_.]{2})[^_.].*[^_.]$")
                                    .WithMessage("Username invalid format - 4 min, 20 max, letters, numbers nad special characters(.,_)")
                                    .Must((user, username) => !context.Users.Any(u => u.Username == username && u.Id != user.Id && u.IsActive))
                                    .WithMessage("Username is already in use");
        }
    }
}

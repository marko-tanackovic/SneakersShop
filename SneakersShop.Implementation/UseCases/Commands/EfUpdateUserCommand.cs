using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SneakersShop.Application.Uploads;
using SneakersShop.Application.UseCases.Commands;
using SneakersShop.Application.UseCases.DTO;
using SneakersShop.DataAccess;
using SneakersShop.Domain.Entities;
using SneakersShop.Implementation.Uploads;
using SneakersShop.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Implementation.UseCases.Commands
{
    public class EfUpdateUserCommand : EfUseCase, IUpdateUserCommand
    {
        private readonly UpdateUserValidator _validator;
        private readonly IBase64FileUploader _uploader;
        public EfUpdateUserCommand(SneakersShopContext context,
                                   UpdateUserValidator validator,
                                   IBase64FileUploader uploader) : base(context)
        {
            _validator = validator;
            _uploader = uploader;
        }

        public int Id => 45;

        public string Name => "Update User";

        public string Description => "Update user with validators";

        public void Execute(UpdateUserDTO request)
        {
            var user = Context.Users.FirstOrDefault(x => x.Id == request.Id);

            _validator.ValidateAndThrow(request);

            if (!string.IsNullOrEmpty(request.Password))
            {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
                user.Password = hashedPassword;
            }

            if (!string.IsNullOrEmpty(request.Address))
            {
                user.Username = request.Address;
            }

            if (!string.IsNullOrEmpty(request.Image))
            {
                user.ProfileImage = new File
                {
                    Path = request.Image,
                    Size = 100
                };
            }

            user.Username = request.Username;
            user.ModifiedAt = DateTime.UtcNow;
            Context.Entry(user).State = EntityState.Modified;

            Context.SaveChanges();
        }
    }
}

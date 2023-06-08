using FluentValidation;
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
    public class EfCreateUserCommand : EfUseCase, ICreateUserCommand
    {
        private readonly CreateUserValidator _validator;
        private readonly IBase64FileUploader _uploader;
        public EfCreateUserCommand(SneakersShopContext context,
                                   CreateUserValidator validator,
                                   IBase64FileUploader uploader) : base(context)
        {
            _validator = validator;
            _uploader = uploader;
        }

        public int Id => 44;

        public string Name => "Register User";

        public string Description => "Register user with validator and file upload";

        public void Execute(CreateUserDTO request)
        {
            _validator.ValidateAndThrow(request);

            Role defaultRole = Context.Roles.FirstOrDefault(x => x.IsDefault);

            if (defaultRole == null)
            {
                throw new InvalidOperationException("Default role doesn't exist");
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var filePath = "default.jpg";

            if (request.Image != null)
            {
                filePath = _uploader.Upload(request.Image, UploadType.ProfileImage);
            }

            var user = new User
            {
                Role = defaultRole,
                Email = request.Email,
                Username = request.Username,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = passwordHash,
                Address = request.Address,
                CityId = request.CityId,
                BirthDate = request.BirthDate,
                Phone = request.Phone,
                ProfileImage = new File
                {
                    Path = filePath,
                    Size = 100
                }
            };

            Context.Users.Add(user);

            Context.SaveChanges();
        }
    }
}

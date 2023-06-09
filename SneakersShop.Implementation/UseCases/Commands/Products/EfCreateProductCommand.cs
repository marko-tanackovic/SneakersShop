using FluentValidation;
using SneakersShop.Application;
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
    public class EfCreateProductCommand : EfUseCase, ICreateProductCommand
    {
        private readonly CreateProductValidator _validator;
        private readonly IBase64FileUploader _uploader;

        public EfCreateProductCommand(SneakersShopContext context,
                                      CreateProductValidator validator,
                                      IBase64FileUploader uploader) : base(context)
        {
            _validator = validator;
            _uploader = uploader;
        }

        public int Id => 2;

        public string Name => "Create Product";

        public string Description => "";


        public void Execute(CreateProductDTO request)
        {
            _validator.ValidateAndThrow(request);

            List<Color> colors = new List<Color>();

            foreach (var color in request.Colors)
            {
                Color fromDb = Context.Colors.Where(x => x.Name == color && x.IsActive)
                                                .FirstOrDefault();

                if (fromDb == null)
                {
                    fromDb = new Color
                    {
                        Name = color,
                        IsActive = true
                    };

                    Context.Colors.Add(fromDb);
                }

                colors.Add(fromDb);
            }

            var filePath = _uploader.Upload(request.Image, UploadType.ProductImage);

            var fileName = filePath.Split("\\").Last();

            Product newProduct = new Product
            {
                Name = request.Name,
                BrandId = request.BrandId,
                Price = request.Price,
                ReleaseDate = request.ReleaseDate,
                Code = request.Code,
                Image = new File
                {
                    Path = fileName,
                    Size = 100
                },
                ProductColors = colors.Select(x => new ProductColor
                {
                    Color = x
                }).ToList()
            };

            

            Context.Products.Add(newProduct);
            Context.SaveChanges();
        }
    }
}

using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SneakersShop.Application.Extensions;
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
    public class EfUpdateProductCommand : EfUseCase, IUpdateProductCommand
    {
        private readonly UpdateProductValidator _validator;
        private readonly IBase64FileUploader _uploader;
        public EfUpdateProductCommand(SneakersShopContext context, 
                                      UpdateProductValidator validator,
                                      IBase64FileUploader uploader) : base(context)
        {
            _validator = validator;
            _uploader = uploader;
        }

        public int Id => 29;

        public string Name => "Update Product";

        public string Description => "Update product using validator";

        public void Execute(UpdateProductDTO request)
        {
            var product = Context.Products.Include(x => x.Reviews)
                                          .Include(x => x.Image)
                                          .Include(x => x.Brand)
                                          .Include(x => x.ProductColors)
                                          .ThenInclude(x => x.Color).FirstOrDefault(x => x.Id == request.Id && x.IsActive);

            if (product == null || !product.IsActive || product.DeletedAt.HasValue)
            {
                throw new EntityNotFoundException(request.Id, nameof(Product));
            }

            _validator.ValidateAndThrow(request);


            if (!string.IsNullOrEmpty(request.Name))
            {
                product.Name = request.Name;
            }

            if (!string.IsNullOrEmpty(request.Code))
            {
                product.Code = request.Code;
            }

            if (request.Price.HasValue)
            {
                product.Price = request.Price.Value;
            }

            if (request.Discount.HasValue)
            {
                product.Discount = request.Discount.Value;
            }

            if (request.BrandId.HasValue)
            {
                product.BrandId = request.BrandId.Value;
            }


            if (request.Image != null)
            {
                var filePath = _uploader.Upload(request.Image, UploadType.ProductImage);

                var image = new File
                {
                    Path = filePath,
                    Size = 100
                };

                Context.Files.Add(image);

                product.Image = image;
            }

            if (request.Colors == null || !request.Colors.Any())
            {
                product.ProductColors.Clear();
            }
            else
            {
                foreach (var color in request.Colors)
                {
                    if (product.ProductColors.Any(x => x.Color.Name == color))
                    {
                        continue;
                    }

                    var dbColor = Context.Colors.FirstOrDefault(x => x.IsActive &&
                                                                         x.Name == color);

                    if (dbColor == null)
                    {
                        product.ProductColors.Add(new ProductColor
                        {
                            Color = new Color
                            {
                                Name = color,
                            }
                        });
                    }
                    else
                    {
                        product.ProductColors.Add(new ProductColor
                        {
                            Color = dbColor
                        });
                    }

                    var colorsToRemove = product.ProductColors.Where(x => !request.Colors.Contains(x.Color.Name));
                    Context.ProductColors.RemoveRange(colorsToRemove);
                }
            }

            product.ModifiedAt = DateTime.UtcNow;
            Context.Entry(product).State = EntityState.Modified;

            Context.SaveChanges();
        }
    }
}

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SneakersShop.API.DTO;
using SneakersShop.API.ErrorLogging;
using SneakersShop.API.Jwt;
using SneakersShop.Application.Logging;
using SneakersShop.Application.Uploads;
using SneakersShop.Application.UseCases.Commands;
using SneakersShop.Application.UseCases.Queries;
using SneakersShop.Implementation.Uploads;
using SneakersShop.Implementation.UseCases.Commands;
using SneakersShop.Implementation.UseCases.Queries;
using SneakersShop.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.API.Extensions
{
    public static class ContainerExtensions
    {
        public static void AddLogger(this IServiceCollection services)
        {
            services.AddTransient<IErrorLogger>(x =>
            {
                var accesor = x.GetService<IHttpContextAccessor>();

                if (accesor == null || accesor.HttpContext == null)
                {
                    return new ConsoleErrorLogger();
                }

                var logger = accesor.HttpContext.Request.Headers["Logger"].FirstOrDefault();

                if (logger == "Console")
                {
                    return new ConsoleErrorLogger();
                }
                else
                {
                    return new BugSnagErrorLogger(x.GetService<Bugsnag.IClient>());
                }
            });
        }

        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<CreateBrandValidator>();
            services.AddTransient<UpdateBrandValidator>();

            services.AddTransient<CreateProductValidator>();
            services.AddTransient<UpdateProductValidator>();

            services.AddTransient<CreateColorValidator>();
            services.AddTransient<UpdateColorValidator>();

            services.AddTransient<CreateStoreValidator>();
            services.AddTransient<UpdateStoreValidator>();

            services.AddTransient<CreateOrderValidator>();
            services.AddTransient<UpdateOrderValidator>();

            services.AddTransient<CreateSizeCategoryValidator>();
            services.AddTransient<UpdateSizeCategoryValidator>();

            services.AddTransient<CreateSizeValidator>();
            services.AddTransient<UpdateSizeValidator>();

            services.AddTransient<CreateReviewValidator>();
            services.AddTransient<UpdateReviewValidator>();

            services.AddTransient<CreateUserValidator>();
            services.AddTransient<UpdateUserValidator>();

            services.AddTransient<CreateCityValidator>();
            services.AddTransient<UpdateCityValidator>();

            services.AddTransient<CreateProductSizeValidator>();
            services.AddTransient<UpdateProductSizeStoreValidator>();

            services.AddTransient<UpdateRoleValidator>();
        }

        public static void AddCommandsQueries(this IServiceCollection services)
        {
            services.AddTransient<IBase64FileUploader, Base64FileUploader>();

            services.AddTransient<ISearchProductsQuery, EfSearchProductsQuery>();
            services.AddTransient<IFindProductQuery, EfFindProductQuery>();
            services.AddTransient<IUpdateProductCommand, EfUpdateProductCommand>();
            services.AddTransient<ICreateProductCommand, EfCreateProductCommand>();
            services.AddTransient<IDeleteProductCommand, EfDeleteProductCommand>();

            services.AddTransient<IGetBrandsQuery, EfGetBrandsQuery>();
            services.AddTransient<IFindBrandQuery, EfFindBrandQuery>();
            services.AddTransient<IUpdateBrandCommand, EfUpdateBrandCommand>();
            services.AddTransient<ICreateBrandCommand, EfCreateBrandCommand>();
            services.AddTransient<IDeleteBrandCommand, EfDeleteBrandCommand>();

            services.AddTransient<IGetColorsQuery, EfGetColorsQuery>();
            services.AddTransient<IFindColorQuery, EfFindColorQuery>();
            services.AddTransient<IUpdateColorCommand, EfUpdateColorCommand>();
            services.AddTransient<ICreateColorCommand, EfCreateColorCommand>();
            services.AddTransient<IDeleteColorCommand, EfDeleteColorCommand>();

            services.AddTransient<IGetStoresQuery, EfGetStoresQuery>();
            services.AddTransient<IFindStoreQuery, EfFindStoreQuery>();
            services.AddTransient<IUpdateStoreCommand, EfUpdateStoreCommand>();
            services.AddTransient<ICreateStoreCommand, EfCreateStoreCommand>();
            services.AddTransient<IDeleteStoreCommand, EfDeleteStoreCommand>();

            services.AddTransient<IGetOrdersQuery, EfGetOrdersQuery>();
            services.AddTransient<IFindOrderQuery, EfFindOrderQuery>();
            services.AddTransient<IUpdateOrderCommand, EfUpdateOrderCommand>();
            services.AddTransient<IDeleteOrderCommand, EfDeleteOrderCommand>();
            services.AddTransient<ICreateOrderCommand, EfCreateOrderCommand>();

            services.AddTransient<IGetSizesQuery, EfGetSizesQuery>();
            services.AddTransient<IFindSizeQuery, EfFindSizeQuery>();
            services.AddTransient<IUpdateSizeCommand, EfUpdateSizeCommand>();
            services.AddTransient<ICreateSizeCommand, EfCreateSizeCommand>();
            services.AddTransient<IDeleteSizeCommand, EfDeleteSizeCommand>();

            services.AddTransient<IGetSizeCategoriesQuery, EfGetSizeCategoriesQuery>();
            services.AddTransient<IFindSizeCategoryQuery, EfFindSizeCategoryQuery>();
            services.AddTransient<IUpdateSizeCategoryCommand, EfUpdateSizeCategoryCommand>();
            services.AddTransient<ICreateSizeCategoryCommand, EfCreateSizeCategoryCommand>();
            services.AddTransient<IDeleteSizeCategoryCommand, EfDeleteSizeCategoryCommand>();

            services.AddTransient<IGetReviewsQuery, EfGetReviewsQuery>();
            services.AddTransient<IFindReviewQuery, EfFindReviewQuery>();
            services.AddTransient<IUpdateReviewCommand, EfUpdateReviewCommand>();
            services.AddTransient<ICreateReviewCommand, EfCreateReviewCommand>();
            services.AddTransient<IDeleteReviewCommand, EfDeleteReviewCommand>();

            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IFindUserQuery, EfFindUserQuery>();
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<ICreateUserCommand, EfCreateUserCommand>();

            services.AddTransient<IGetCitiesQuery, EfGetCitiesQuery>();
            services.AddTransient<IFindCityQuery, EfFindCityQuery>();
            services.AddTransient<IDeleteCityCommand, EfDeleteCityCommand>();
            services.AddTransient<ICreateCityCommand, EfCreateCityCommand>();
            services.AddTransient<IUpdateCityCommand, EfUpdateCityCommand>();

            services.AddTransient<ICreateProductSizeCommand, EfCreateProductSizeCommand>();
            services.AddTransient<IUpdateProductSizeStoreCommand, EfUpdateProductSizeStoreCommand>();

            services.AddTransient<IGetRolesQuery, EfGetRolesQuery>();
            services.AddTransient<IUpdateRoleCommand, EfUpdateRoleCommand>();
            services.AddTransient<ISearchLogEntriesQuery, EfSearchLogEntriesQuery>();
        }

        public static void AddJwt(this IServiceCollection services, AppSettings settings)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.Jwt.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Jwt.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                cfg.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        //Token dohvatamo iz Authorization header-a

                        var header = context.Request.Headers["Authorization"];

                        var token = header.ToString().Split("Bearer ")[1];

                        var handler = new JwtSecurityTokenHandler();

                        var tokenObj = handler.ReadJwtToken(token);

                        string jti = tokenObj.Claims.FirstOrDefault(x => x.Type == "jti").Value;


                        //ITokenStorage

                        ITokenStorage storage = context.HttpContext.RequestServices.GetService<ITokenStorage>();

                        bool isValid = storage.TokenExists(jti);

                        if (!isValid)
                        {
                            context.Fail("Token is not valid.");
                        }

                        return Task.CompletedTask;
                    }
                };
            });
        }
    }
}

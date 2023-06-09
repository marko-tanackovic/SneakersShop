using Bugsnag.AspNet.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using SneakersShop.API.DTO;
using SneakersShop.API.Extensions;
using SneakersShop.API.Jwt;
using SneakersShop.API.Jwt.TokenStorage;
using SneakersShop.API.Middleware;
using SneakersShop.Application;
using SneakersShop.Application.Logging;
using SneakersShop.Application.Uploads;
using SneakersShop.Application.UseCaseHandling;
using SneakersShop.Application.UseCases.Commands;
using SneakersShop.Application.UseCases.Queries;
using SneakersShop.DataAccess;
using SneakersShop.Implementation.Logging;
using SneakersShop.Implementation.Uploads;
using SneakersShop.Implementation.UseCases.Commands;
using SneakersShop.Implementation.UseCases.Queries;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = new AppSettings();
            Configuration.Bind(appSettings);

            services.AddTransient<ITokenStorage, InMemoryTokenStorage>();
            services.AddTransient<JwtManager>(x =>
            {
                var context = x.GetService<SneakersShopContext>();
                var tokenStorage = x.GetService<ITokenStorage>();
                return new JwtManager(context, appSettings.Jwt.Issuer, appSettings.Jwt.SecretKey, appSettings.Jwt.DurationSeconds, tokenStorage);
            });

            services.AddBugsnag(configuration => {
                configuration.ApiKey = appSettings.BugSnagKey;
            });

            services.AddLogger();
            services.AddValidators();

            services.AddScoped<SneakersShopContext>(x =>
            {
                DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
                builder.UseSqlServer("Data Source=DESKTOP-RFBQSM7\\SQLEXPRESS;Initial Catalog=BazaZaAsp;Integrated Security=True");
                return new SneakersShopContext(builder.Options);
            });

            services.AddTransient<QueryHandler>();

            services.AddHttpContextAccessor();
            services.AddScoped<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var header = accessor.HttpContext.Request.Headers["Authorization"];

                var data = header.ToString().Split("Bearer ");

                if (data.Length < 2)
                {
                    return new UnauthorizedActor();
                }

                var handler = new JwtSecurityTokenHandler();

                var tokenObj = handler.ReadJwtToken(data[1].ToString());

                var claims = tokenObj.Claims;

                var email = claims.First(x => x.Type == "Email").Value;
                var id = claims.First(x => x.Type == "Id").Value;
                var username = claims.First(x => x.Type == "Username").Value;
                var useCases = claims.First(x => x.Type == "UseCases").Value;

                List<int> useCaseIds = JsonConvert.DeserializeObject<List<int>>(useCases);

                return new JwtActor
                {
                    Email = email,
                    AllowedUseCases = useCaseIds,
                    Id = int.Parse(id),
                    Username = username,
                };
            });

            services.AddCommandsQueries();

            services.AddTransient<IUseCaseLogger, EfUseCaseLogger>();
            services.AddTransient<ICommandHandler, CommandHandler>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SneakersShop.API", Version = "v1" });
            });

            services.AddJwt(appSettings);

            services.AddTransient<IQueryHandler>(x =>
            {
                var actor = x.GetService<IApplicationActor>();
                var logger = x.GetService<IUseCaseLogger>();
                var queryHandler = new QueryHandler();
                var timeTrackingHandler = new TimeTrackingQueryHandler(queryHandler);
                var loggingHandler = new LoggingQueryHandler(timeTrackingHandler, actor, logger);
                var decoration = new AuthorizationQueryHandler(actor, loggingHandler);

                return decoration;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SneakersShop.API v1"));


            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();


            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

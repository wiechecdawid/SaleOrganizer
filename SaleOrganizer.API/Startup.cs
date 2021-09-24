using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SaleOrganizer.API.Extensions;
using SaleOrganizer.API.Middleware;
using SaleOrganizer.Application.Clothes;
using SaleOrganizer.Application.Interfaces;
using SaleOrganizer.Application.Mappings;
using SaleOrganizer.Infrastructure.Photos;
using SaleOrganizer.Persistence;
using SaleOrganizer.Persistence.DbInitializer;

namespace SaleOrganizer.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(cfg => {
                    cfg.RegisterValidatorsFromAssemblyContaining<Create>();
                });

            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped<IPhotoAccessor, PhotoAccessor>();
            services.AddMediatR(typeof(Get.Handler).Assembly);
            services.Configure<CloudinarySettings>(Configuration.GetSection("Cloudinary"));
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddIdentityServices(Configuration);

            services.AddDbContext<DataContext>(options =>
            {
                //options.UseSqlite(Configuration.GetConnectionString("Default"));
                options.UseNpgsql(Configuration.GetConnectionString("Default"));
            });

            services.AddCors(options =>
           {
               options.AddPolicy("LocalPolicy", policy =>
               {
                   policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
               });
           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();

            if (env.IsDevelopment())
            {
                var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
                using (var scope = scopeFactory.CreateScope())
                {
                    var initializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
                    initializer.Initialize().Wait();
                    initializer.Seed().Wait();
                }
                //app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("LocalPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

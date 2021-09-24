using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SaleOrganizer.Domain;
using SaleOrganizer.Persistence;
using Microsoft.AspNetCore.Identity;

namespace SaleOrganizer.API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentityCore<AppUser>( opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<DataContext>()
            .AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication();

            return services;
        }
    }
}
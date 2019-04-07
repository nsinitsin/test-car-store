using System;
using CatSolutions.BL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CatSolutions.BL
{
    public static class IocContainerExtensions
    {
        public static void AddCarSlnBL(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IManufacturerService, ManufacturerService>();

        }
    }
}
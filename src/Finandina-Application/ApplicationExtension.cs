using System.Reflection;
using Finandina_Application.Feature.Region;
using Finandina_Domain.Interface.Region;
using Microsoft.Extensions.DependencyInjection;

namespace Finandina_Application
{
    public static class ApplicationExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(Assembly.GetExecutingAssembly());
            });

            services.AddScoped(typeof(Validators<>));

            services.AddScoped<IRegionService, RegionService>();
        }
    }
}

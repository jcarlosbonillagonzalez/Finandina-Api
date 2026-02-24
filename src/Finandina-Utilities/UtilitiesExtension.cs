using Finandina_Domain.Interface;
using Finandina_Utilities.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Finandina_Utilities
{
    public static class UtilitiesExtension
    {
        public static void AddUtilities(this IServiceCollection services)
        {
            services.AddMemoryCache();
            
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<ICurrentTenantProvider, CurrentTenantProvider>();
        }
    }
}

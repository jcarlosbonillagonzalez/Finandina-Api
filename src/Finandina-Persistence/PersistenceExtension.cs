using Finandina_Persistence.Context;
using Finandina_Persistence.Context.Interceptors;
using Finandina_Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Finandina_Persistence
{
    public static class PersistenceExtension
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'DefaultConnection'.");

            services.AddDbContext<ApplicationContext>((sp, options) =>
            {
                var interceptor = sp.GetRequiredService<TimestampInterceptor>();
                options.UseSqlServer(connectionString,
                    sql => sql.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName))
                    .AddInterceptors(interceptor);
            });

            services.AddScoped<TimestampInterceptor>();
            services.AddRepositories();
        }
    }
}

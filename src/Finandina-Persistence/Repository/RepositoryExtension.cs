using Finandina_Domain.Interface;
using Finandina_Domain.Interface.Region;
using Finandina_Persistence.Repository.Base;
using Finandina_Persistence.Repository.Region;
using Microsoft.Extensions.DependencyInjection;

namespace Finandina_Persistence.Repository
{
    public static class RepositoryExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuditoriaConsultaRegionRepository, AuditoriaConsultaRegionRepository>();
        }
    }
}

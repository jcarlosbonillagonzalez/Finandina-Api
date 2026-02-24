using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ColombiaApiClient = Finandina_External.ColombiaApi.ColombiaApi;

namespace Finandina_External
{
    public static class ExternalExtension
    {
        public static void AddExternal(this IServiceCollection services, IConfiguration configuration)
        {
            var baseUrl = configuration["ExternalApis:ColombiaApi:BaseUrl"]
                          ?? "https://api-colombia.com";

            services.AddHttpClient(nameof(ColombiaApiClient), client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });

            services.AddTransient<ColombiaApiClient>(sp =>
            {
                var factory = sp.GetRequiredService<IHttpClientFactory>();
                var httpClient = factory.CreateClient(nameof(ColombiaApiClient));
                return new ColombiaApiClient(baseUrl, httpClient);
            });
        }
    }
}

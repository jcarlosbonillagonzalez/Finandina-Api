using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Finandina_Api.Extensions
{
    public static class SwaggerExtension
    {
        public static void UseSwaggerExtension(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            var version = Environment.GetEnvironmentVariable("VERSION") ?? "1";
            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = version,
                    Title = $"Finandina-API",
                    Description = "API de Finandina Prueba Técnica"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "Use Bearer <token>"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id   = "Bearer"
                            }
                        },
                        new List<string>()
                    }
                });
            });
        }
    }
}

using CompanySystem.Application.Common.Interfaces.Persistence;
using CompanySystem.Infrastructure.Persistence;
using CompanySystem.Infrastructure.Persistence.Interceptors;
using CompanySystem.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanySystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configurations)
        {
            services.AddPersistence();
            services.AddCorsPolicy(configurations);
            services.AddCache(configurations);
            services.AddHealthCheck(configurations);

            return services;
        }

        public static IServiceCollection AddCache(this IServiceCollection services, ConfigurationManager configuration)
        {

            string redisConnectionString = configuration.GetConnectionString("Cache")!;

            services.AddStackExchangeRedisCache(options =>
                options.Configuration = redisConnectionString);

            return services;
        }

        public static IServiceCollection AddCorsPolicy(this IServiceCollection services, ConfigurationManager configurations)
        {
            var allowedOrigins = configurations.GetSection("AllowedOrigins").Get<string[]>();
            if (allowedOrigins is not null)
            {
                services.AddCors(options =>
                {
                    options.AddPolicy("AllowAllOrigins",
                        builder =>
                        {
                            builder.WithOrigins(allowedOrigins);
                            builder.AllowAnyMethod();
                            builder.AllowAnyHeader();
                            builder.AllowCredentials();
                        });
                });
            }

            return services;
        }

        public static IServiceCollection AddHealthCheck(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddHealthChecks()
                .AddNpgSql(configuration.GetConnectionString("DefaultConnection")!);

            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<CompanySystemDbContext>(
                    options => options.UseNpgsql()
            );

            services.AddScoped<ICompanyRepository, CompanyRepository>();

            services.AddScoped<PublishDomainEventsInterceptor>();
            return services;
        }
    }
}

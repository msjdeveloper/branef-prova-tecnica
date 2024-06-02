using CompanySystem.API.Common.Errors;
using CompanySystem.API.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CompanySystem.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, CompanySystemProblemDetailsFactory>();
            services.AddMappings();

            return services;
        }
    }
}

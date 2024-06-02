using CompanySystem.Application.Common.Behavior;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CompanySystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly));

            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(RequestLoggingPipelineBehavior<,>)
            );

            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidateBehavior<,>)
            );

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}

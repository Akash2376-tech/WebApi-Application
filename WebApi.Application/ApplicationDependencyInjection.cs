using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WebApi.Application.Common.Behaviour;
using WebApi.Application.Common.Mappings;

namespace WebApi.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            // MediatR
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // AutoMapper
            services.AddAutoMapper(typeof(MappingProfile));

            // Validation

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Registring Validation

            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));

            return services;
        }

    }
}

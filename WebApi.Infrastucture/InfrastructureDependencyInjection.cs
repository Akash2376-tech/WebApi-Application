using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Interfaces;
using WebApi.Infrastucture.Interfaces;
using WebApi.Infrastucture.Repositories;

namespace WebApi.Infrastucture
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IDbConnectionFactory, SqlConnectionFactory>();

            return services;
        }

    }
}

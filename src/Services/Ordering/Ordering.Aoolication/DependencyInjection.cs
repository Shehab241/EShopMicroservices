using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BuildingBlocks.Messaging.MassTransit;
using Microsoft.FeatureManagement;
namespace Ordering.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                //config.AddOpenBehavior(typeof(ValidationBehavior<,>));
                //config.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });

            services.AddFeatureManagement();
            services.AddMessageBroker(configuration, Assembly.GetExecutingAssembly());

            return services;
        }
    }
}

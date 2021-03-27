using System;
using System.Linq;
using FluxToken.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluxToken.Infrastructure.Extensions
{
    public static class ServiceRegistrationExtension
    {
        public static void AddServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var appServices = typeof(Startup).Assembly.DefinedTypes
                                .Where(x => typeof(IServiceRegistration)
                                .IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                                .Select(Activator.CreateInstance)
                                .Cast<IServiceRegistration>().ToList();
            
            appServices.ForEach(svc => svc.RegisterApplicationServices(services, configuration));
        }
    }
}
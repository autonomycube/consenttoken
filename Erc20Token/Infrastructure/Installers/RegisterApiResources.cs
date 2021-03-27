using FluxToken.Contracts;
using FluxToken.Infrastructure.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluxToken.Infrastructure.Installers
{
    public class RegisterApiResources : IServiceRegistration
    {
        public void RegisterApplicationServices(IServiceCollection services, IConfiguration configuration)
        {
            var appConfigSection = configuration.GetSection(nameof(AppConfig));
            services.Configure<AppConfig>(appConfigSection);
        }
    }
}
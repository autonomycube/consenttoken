using FluxToken.Contracts;
using FluxToken.Services;
using FluxToken.Services.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluxToken.Infrastructure.Installers
{
    public class RegisterServices : IServiceRegistration
    {
        public void RegisterApplicationServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IFluxTokenService, FluxTokenService>();
        }
    }
}
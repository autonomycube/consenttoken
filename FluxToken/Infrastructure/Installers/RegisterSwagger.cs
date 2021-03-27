using FluxToken.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace FluxToken.Infrastructure.Installers
{
    public class RegisterSwagger : IServiceRegistration
    {
        public void RegisterApplicationServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Flux Token API",
                    Version = "v1"
                });
            });
        }
    }
}
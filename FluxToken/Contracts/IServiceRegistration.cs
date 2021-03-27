using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluxToken.Contracts
{
    public interface IServiceRegistration
    {
        void RegisterApplicationServices(IServiceCollection services, IConfiguration configuration);
    }
}
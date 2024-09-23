using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiEmailSender.Infraestructure.DependencyConfiguration
{
    public static class DependencyContainer
    {
        public static void UseDependencyContainerInfraestructure(this IServiceCollection services, IConfiguration configuration)
        { 
        }
    }
}

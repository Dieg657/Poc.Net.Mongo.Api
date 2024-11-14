using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poc.Net.Mongo.Setup.Modules;

namespace Poc.Net.Mongo.Setup
{
    public static class Setup
    {
        public static IServiceCollection RegisterContainer(this IServiceCollection services, IConfiguration configuration)
            => services.RegisterContainerInfra(configuration)
                       .RegisterDataModules()
                       .RegisterDomainModules();
    }
}

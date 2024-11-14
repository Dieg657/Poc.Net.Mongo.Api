using Microsoft.Extensions.DependencyInjection;
using Poc.Net.Mongo.Domain.Maps;

namespace Poc.Net.Mongo.Setup.Modules
{
    internal static class DataModules
    {
        public static IServiceCollection RegisterDataModules(this IServiceCollection services)
            => services.RegisterBsonMaps();

        private static IServiceCollection RegisterBsonMaps(this IServiceCollection services)
            => services.RegisterClientMap();
    }
}

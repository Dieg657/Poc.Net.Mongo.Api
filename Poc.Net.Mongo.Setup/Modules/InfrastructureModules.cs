using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Poc.Net.Mongo.Domain.Documents;
using Poc.Net.Mongo.Domain.Interfaces.Repository;
using Poc.Net.Mongo.Infra.CrossCutting.Configs;
using Poc.Net.Mongo.Infra.Repository;

namespace Poc.Net.Mongo.Setup.Modules
{
    internal static class InfrastructureModules
    {
        public static IServiceCollection RegisterContainerInfra(this IServiceCollection services, IConfiguration configuration)
            => services.RegisterMongo(configuration)
                       .RegisterConfigs(configuration)
                       .RegisterRepositories()
                       .AddChecks(configuration);

        private static IServiceCollection RegisterMongo(this IServiceCollection services, IConfiguration configuration)
            => services.AddSingleton<IMongoClient>(x => new MongoClient(configuration.GetConnectionString("MONGODB")));

        private static IServiceCollection RegisterConfigs(this IServiceCollection services, IConfiguration configuration)
            => services.AddSingleton(configuration.GetSection(ClientDatabaseConfig.SettingsKey).Get<ClientDatabaseConfig>());

        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
            => services.AddScoped<IClientRepository<Client>, ClientRepository>();

        private static IServiceCollection AddChecks(this IServiceCollection services, IConfiguration configuration)
            => services.AddHealthChecks()
                       .AddCheck<MongoHealthcheck>("MongoDb").Services;

    }
}

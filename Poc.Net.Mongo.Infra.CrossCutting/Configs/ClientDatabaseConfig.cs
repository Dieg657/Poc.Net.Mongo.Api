using Poc.Net.Mongo.Infra.CrossCutting.Interfaces.Config;

namespace Poc.Net.Mongo.Infra.CrossCutting.Configs
{
    public class ClientDatabaseConfig : IMongoDatabaseConfig
    {
        public const string SettingsKey = "ClientDatabaseConfig";
        public string Name { get; set; }
    }
}

using MongoDB.Driver;
using Poc.Net.Mongo.Infra.CrossCutting.Interfaces.Config;

namespace Poc.Net.Mongo.Infra.Connections
{
    public abstract class BaseMongoRepository<TDocument> where TDocument : class
    {
        private readonly IMongoClient _client;
        protected readonly IMongoCollection<TDocument> _collection;
        public BaseMongoRepository(IMongoClient client, IMongoDatabaseConfig config) 
        {
            _client = client;
            _collection = _client.GetDatabase(config.Name).GetCollection<TDocument>(typeof(TDocument).Name.ToUpperInvariant());
        }
    }
}

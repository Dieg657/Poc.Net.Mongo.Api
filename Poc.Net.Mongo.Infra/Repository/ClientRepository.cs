using MongoDB.Driver;
using Poc.Net.Mongo.Domain.Documents;
using Poc.Net.Mongo.Domain.Interfaces.Repository;
using Poc.Net.Mongo.Infra.Connections;
using Poc.Net.Mongo.Infra.CrossCutting.Configs;
using System.Linq.Expressions;

namespace Poc.Net.Mongo.Infra.Repository
{
    public class ClientRepository : BaseMongoRepository<Client>, IClientRepository<Client>
    {
        public ClientRepository(IMongoClient client, ClientDatabaseConfig config) 
            : base(client, config) { }

        public async Task Add(Client document)
            => await _collection.InsertOneAsync(document);

        public async Task AddRange(IEnumerable<Client> documents)
            => await _collection.InsertManyAsync(documents);

        public async Task<Client> Get(Expression<Func<Client, bool>> expression)
            => (await _collection.FindAsync(expression)).FirstOrDefault();

        public async Task<IReadOnlyCollection<Client>> GetAll(Expression<Func<Client, bool>> expression)
            => (await _collection.FindAsync(expression)).ToList();

        public async Task<bool> Remove(Expression<Func<Client, bool>> expression)
            => (await _collection.DeleteOneAsync(expression)).DeletedCount > 0;
    }
}

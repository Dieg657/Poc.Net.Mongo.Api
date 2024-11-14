namespace Poc.Net.Mongo.Domain.Interfaces.Repository
{
    public interface IClientRepository<TDocument> : IMongoQueryRepository<TDocument>, IMongoInsertRepository<TDocument>, IMongoRemoveRepository<TDocument>
    {
    }
}

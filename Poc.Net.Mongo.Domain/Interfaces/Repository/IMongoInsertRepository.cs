namespace Poc.Net.Mongo.Domain.Interfaces.Repository
{
    public interface IMongoInsertRepository<TDocument>
    {
        Task Add(TDocument document);
        Task AddRange(IEnumerable<TDocument> documents);
    }
}

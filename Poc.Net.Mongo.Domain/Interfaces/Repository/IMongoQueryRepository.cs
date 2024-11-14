using System.Linq.Expressions;

namespace Poc.Net.Mongo.Domain.Interfaces.Repository
{
    public interface IMongoQueryRepository<TDocument>
    {
        Task<IReadOnlyCollection<TDocument>> GetAll(Expression<Func<TDocument, bool>> expression);
        Task<TDocument> Get(Expression<Func<TDocument, bool>> expression);
    }
}

using Poc.Net.Mongo.Domain.Documents;
using System.Linq.Expressions;

namespace Poc.Net.Mongo.Domain.Interfaces.Repository
{
    public interface IMongoRemoveRepository<TDocument>
    {
        Task<bool> Remove(Expression<Func<Client, bool>> expression);
    }
}


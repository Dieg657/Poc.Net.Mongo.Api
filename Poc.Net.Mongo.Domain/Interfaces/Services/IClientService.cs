using Poc.Net.Mongo.Domain.Documents;
using System.Linq.Expressions;

namespace Poc.Net.Mongo.Domain.Interfaces.Services
{
    public interface IClientService
    {
        Task<Client> GetClient(Expression<Func<Client, bool>> filter);
        Task<IEnumerable<Client>> GetAllClients(Expression<Func<Client, bool>> filter);
        Task AddClient(Client client);
        Task<bool> RemoveClient(Expression<Func<Client, bool>> filter);
    }
}

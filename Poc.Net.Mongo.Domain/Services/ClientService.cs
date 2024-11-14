using FluentValidation;
using Microsoft.Extensions.Logging;
using Poc.Net.Mongo.Domain.Documents;
using Poc.Net.Mongo.Domain.Interfaces.Repository;
using Poc.Net.Mongo.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace Poc.Net.Mongo.Domain.Services
{
    public class ClientService : IClientService
    {
        private readonly ILogger<ClientService> _logger;
        private readonly IValidator<Client> _validator;
        private readonly IClientRepository<Client> _repository;

        public ClientService(ILogger<ClientService> logger, IValidator<Client> validator, IClientRepository<Client> repository)
        {
            _logger = logger;
            _validator = validator;
            _repository = repository;
        }

        public async Task AddClient(Client client)
        {
            _logger.LogInformation($"Starting {nameof(ClientService)}-{nameof(AddClient)}");
            var validationResult = await _validator.ValidateAsync(client);
            if (validationResult.IsValid)
                await _repository.Add(client);
            else
                throw new InvalidOperationException();
            _logger.LogInformation($"Finishing {nameof(ClientService)}-{nameof(AddClient)}");
        }

        public async Task<IEnumerable<Client>> GetAllClients(Expression<Func<Client, bool>> filter)
        {
            _logger.LogInformation($"Starting {nameof(ClientService)}-{nameof(GetAllClients)}");
            var clients = await _repository.GetAll(filter);
            _logger.LogInformation($"Finishing {nameof(ClientService)}-{nameof(GetAllClients)}");
            return clients;
        }

        public async Task<Client> GetClient(Expression<Func<Client, bool>> filter)
        {
            _logger.LogInformation($"Starting {nameof(ClientService)}-{nameof(GetClient)}");
            var client = await _repository.Get(filter);
            _logger.LogInformation($"Finishing {nameof(ClientService)}-{nameof(GetClient)}");
            return client;
        }

        public async Task<bool> RemoveClient(Expression<Func<Client, bool>> filter)
        {
            _logger.LogInformation($"Starting {nameof(ClientService)}-{nameof(RemoveClient)}");
            var result = await _repository.Remove(filter);
            _logger.LogInformation($"Finishing {nameof(ClientService)}-{nameof(RemoveClient)}");

            return result;
        }
    }
}

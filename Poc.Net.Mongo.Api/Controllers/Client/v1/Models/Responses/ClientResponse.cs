using Poc.Net.Mongo.Api.Controllers.Client.v1.Models.Base;

namespace Poc.Net.Mongo.Api.Controllers.Client.v1.Models.Responses
{
    public class ClientResponse : IBaseClient
    {
        public DateTimeOffset CreatedAt { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime BirthDate { get; set; }

        public static implicit operator ClientResponse(Domain.Documents.Client client)
            => new()
            {
                Name = client.Name,
                Document = client.Document,
                BirthDate = client.BirthDate,
                CreatedAt = client.CreatedAt
            };
    }
}

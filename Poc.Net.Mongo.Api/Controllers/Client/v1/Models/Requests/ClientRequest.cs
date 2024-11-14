using Poc.Net.Mongo.Api.Controllers.Client.v1.Models.Base;

namespace Poc.Net.Mongo.Api.Controllers.Client.v1.Models.Requests
{
    public class ClientRequest : IBaseClient
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime BirthDate { get; set; }
    }
}

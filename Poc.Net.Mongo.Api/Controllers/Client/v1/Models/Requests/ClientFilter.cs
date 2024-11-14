namespace Poc.Net.Mongo.Api.Controllers.Client.v1.Models.Requests
{
    public class ClientFilter : ClientBaseFilter
    {
        public string Name { get; set; } = string.Empty;
    }
}

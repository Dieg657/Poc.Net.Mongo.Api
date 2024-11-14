namespace Poc.Net.Mongo.Api.Controllers.Client.v1.Models.Base
{
    internal interface IBaseClient
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime BirthDate { get; set; }
    }
}

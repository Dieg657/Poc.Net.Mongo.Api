using Poc.Net.Mongo.Domain.Interfaces.Entities.Base;

namespace Poc.Net.Mongo.Domain.Documents
{
    public class Client : IBaseEntity
    {
        public string Name { get; set; }
        public string Document {  get; set; }
        public DateTime BirthDate { get; set; }
        public DateTimeOffset CreatedAt { get; init; }
        public string CreatedBy { get; init; }

        public Client() {}

        public Client(string name, string document, DateTime birthDate)
        {
            Name = name;
            Document = document;
            BirthDate = birthDate;
            CreatedAt = DateTimeOffset.Now;
            CreatedBy = Environment.MachineName;
        }
    }
}

namespace Poc.Net.Mongo.Domain.Interfaces.Entities.Base
{
    public interface IBaseEntity
    {
        public DateTimeOffset CreatedAt { get; }
        public string CreatedBy { get; }
    }
}

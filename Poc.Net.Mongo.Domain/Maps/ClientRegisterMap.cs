using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using Poc.Net.Mongo.Domain.Documents;

namespace Poc.Net.Mongo.Domain.Maps
{
    public static class ClientRegisterMap
    {
        public static IServiceCollection RegisterClientMap(this IServiceCollection services)
        {
            BsonClassMap.RegisterClassMap<Client>(cfg =>
            {
                cfg.MapMember(p => p.Name).SetElementName("NAME");
                cfg.MapMember(p => p.Document).SetElementName("DOCUMENT");
                cfg.MapMember(p => p.BirthDate).SetElementName("BIRTHDATE");
                cfg.MapMember(p => p.CreatedAt).SetElementName("CREATED_AT");
                cfg.MapMember(p => p.CreatedBy).SetElementName("CREATED_BY");
                cfg.SetIgnoreExtraElements(true);
            });

            return services;
        }
    }
}

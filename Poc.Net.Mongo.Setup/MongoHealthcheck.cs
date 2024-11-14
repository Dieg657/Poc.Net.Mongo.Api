using Microsoft.Extensions.Diagnostics.HealthChecks;
using MongoDB.Driver;

namespace Poc.Net.Mongo.Setup
{
    public class MongoHealthcheck : IHealthCheck
    {
        private readonly IMongoClient _mongoClient;

        public MongoHealthcheck(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                await _mongoClient.ListDatabasesAsync(cancellationToken);
                return HealthCheckResult.Healthy();
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy("MongoDB Unhealthy", ex);
            }
        }
    }
}

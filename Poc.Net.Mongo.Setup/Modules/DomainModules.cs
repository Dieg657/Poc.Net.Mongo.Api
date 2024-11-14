using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Poc.Net.Mongo.Domain.Documents;
using Poc.Net.Mongo.Domain.Interfaces.Services;
using Poc.Net.Mongo.Domain.Services;
using Poc.Net.Mongo.Domain.Validators;

namespace Poc.Net.Mongo.Setup.Modules
{
    internal static class DomainModules
    {
        public static IServiceCollection RegisterDomainModules(this IServiceCollection services)
            => services.RegisterValidators()
                       .RegisterServices();

        private static IServiceCollection RegisterValidators(this IServiceCollection services)
            => services.AddScoped<IValidator<Client>, ClientDocumentValidator>();
        private static IServiceCollection RegisterServices(this IServiceCollection services)
            => services.AddScoped<IClientService, ClientService>();
    }
}

using CleanArchitectureAPi.Application.Common.Interfaces.Authentication;
using CleanArchitectureAPi.Application.Common.Interfaces.Persistence;
using CleanArchitectureAPi.Application.Common.Interfaces.Services;
using CleanArchitectureAPi.Application.Services.Authentication;
using CleanArchitectureAPi.Application.Services.Authentication.Commands.Interface;
using CleanArchitectureAPi.Infrastructure.Authentication;
using CleanArchitectureAPi.Infrastructure.Persistence;
using CleanArchitectureAPi.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureAPi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, Microsoft.Extensions.Configuration.ConfigurationManager configuration)
    {
        // Gets the configuration for the given section.
        serviceCollection.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        
        // Adds singleton services to the service collection
        serviceCollection.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator>();
        serviceCollection.AddSingleton<IDateTimeProvider,DateTimeProvider>();

        // Adds a scoped service to the service collection
        serviceCollection.AddScoped<IUserRepository,UserRepository>();

        // Returns a service collection.
        return serviceCollection;
    }
}
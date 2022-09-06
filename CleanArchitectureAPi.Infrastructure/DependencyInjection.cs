using CleanArchitectureAPi.Application.Common.Interfaces.Authentication;
using CleanArchitectureAPi.Application.Common.Interfaces.Persistence;
using CleanArchitectureAPi.Application.Common.Interfaces.Services;
using CleanArchitectureAPi.Application.Services.Authentication;
using CleanArchitectureAPi.Application.Services.Interface;
using CleanArchitectureAPi.Infrastructure.Authentication;
using CleanArchitectureAPi.Infrastructure.Persistence;
using CleanArchitectureAPi.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureAPi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, Microsoft.Extensions.Configuration.ConfigurationManager configuration)
    {
        serviceCollection.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        
        serviceCollection.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator>();
        serviceCollection.AddSingleton<IDateTimeProvider,DateTimeProvider>();

        serviceCollection.AddScoped<IUserRepository,UserRepository>();

        return serviceCollection;
    }
}
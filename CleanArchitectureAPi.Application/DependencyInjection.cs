using CleanArchitectureAPi.Application.Services.Authentication;
using CleanArchitectureAPi.Application.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureAPi.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        // Adds scoped AuthenticationServices to the collection.
        serviceCollection.AddScoped<IAuthenticationServices,AuthenticationServices>();
        return serviceCollection;
    }
}
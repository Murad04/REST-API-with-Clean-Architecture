using CleanArchitectureAPi.Application.Services.Authentication.Commands;
using CleanArchitectureAPi.Application.Services.Authentication.Commands.Interface;
using CleanArchitectureAPi.Application.Services.Authentication.Queries.Login;
using CleanArchitectureAPi.Application.Services.Authentication.Queries.Login.Interface;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureAPi.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        // Adds scoped AuthenticationServices to the collection.
        //serviceCollection.AddScoped<IAuthenticationcommandServices, AuthenticationCommandServices>();
        //serviceCollection.AddScoped<IAuthenticationQueryServices, AuthenticationQueryServices>();


        // Added MediatR to services
        serviceCollection.AddMediatR(typeof(DependencyInjection).Assembly);

        return serviceCollection;
    }
}
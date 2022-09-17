using System.Reflection;
using CleanArchitectureAPi.Application.Authentication.Commands.Register;
using CleanArchitectureAPi.Application.Authentication.Common;
using CleanArchitectureAPi.Application.Common.Behaviors;
using CleanArchitectureAPi.Application.Services.Authentication.Commands;
using CleanArchitectureAPi.Application.Services.Authentication.Commands.Interface;
using CleanArchitectureAPi.Application.Services.Authentication.Queries.Login;
using CleanArchitectureAPi.Application.Services.Authentication.Queries.Login.Interface;
using ErrorOr;
using FluentValidation;
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

        serviceCollection.AddScoped(
                            typeof(IPipelineBehavior<,>),
                            typeof(ValidateRegisterCommandBehavior<,>));

        serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        return serviceCollection;
    }
}
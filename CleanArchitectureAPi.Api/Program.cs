using CleanArchitectureAPi.Api.Common.Errors;
using CleanArchitectureAPi.Api.Filters;
//using CleanArchitectureAPi.Api.Middleware;
using CleanArchitectureAPi.Application;
using CleanArchitectureAPi.Application.Services.Authentication;
using CleanArchitectureAPi.Application.Services.Authentication.Commands.Interface;
using CleanArchitectureAPi.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Adds the application and infrastructure.
builder.Services.AddApplication().AddInfrastructure(builder.Configuration);

// This is used for adding custom error handling middleware
//builder.Services.AddControllers(options=>options.Filters.Add<ErrorHandling_FilterAttribute>());
builder.Services.AddControllers();

builder.Services.AddSingleton<ProblemDetailsFactory,CleanArchitectureAPiProblemDetailsFactory>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// This is used for adding custom error handling middleware
//app.UseMiddleware<ErrorHandling_Middleware>();

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

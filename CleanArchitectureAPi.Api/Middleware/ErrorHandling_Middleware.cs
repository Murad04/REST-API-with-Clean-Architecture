using System.Net;
using System.Text.Json;

namespace CleanArchitectureAPi.Api.Middleware;

public class ErrorHandling_Middleware
{
    private readonly RequestDelegate _next;

    public ErrorHandling_Middleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    // Handle an exception asynchronously.
    public static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var code = HttpStatusCode.InternalServerError; //500 if unexpected
        // Convert a JSON object to a json string.
        var result = JsonSerializer.Serialize(new {error="An error occured while processing your request."});
        context.Response.ContentType="application/json";
        context.Response.StatusCode=(int)code;
        // Asynchronously sends a response to the client.
        return context.Response.WriteAsync(result);
    }
}
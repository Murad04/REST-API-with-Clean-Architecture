using System.Net;

namespace CleanArchitectureAPi.Application.Common.Errors.Interface;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}
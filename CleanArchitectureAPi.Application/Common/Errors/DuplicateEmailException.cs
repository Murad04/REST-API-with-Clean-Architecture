using System.Net;
using CleanArchitectureAPi.Application.Common.Errors.Interface;

namespace CleanArchitectureAPi.Application.Common.Errors;

public class DuplicateEmailException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "Email already exists";
}
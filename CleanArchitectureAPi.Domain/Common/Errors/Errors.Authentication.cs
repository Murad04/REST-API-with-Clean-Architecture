using ErrorOr;

namespace CleanArchitectureAPi.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials=>Error.Validation(code:"Auth.Invalidcredentials",description:"Invalid credentials enterd.");
    }
}
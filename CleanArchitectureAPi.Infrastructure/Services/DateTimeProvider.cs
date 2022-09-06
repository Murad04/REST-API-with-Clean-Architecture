using CleanArchitectureAPi.Application.Common.Interfaces.Services;

namespace CleanArchitectureAPi.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}

using Traceability.SharedKernel;

namespace Traceability.Infrastructure;

public sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}
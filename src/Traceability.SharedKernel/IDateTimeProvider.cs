namespace Traceability.SharedKernel;

public interface IDateTimeProvider
{
    DateTimeOffset UtcNow { get; }
}
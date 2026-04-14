using Traceability.Domain.ProcessSegments.Errors;

namespace Traceability.Domain.ProcessSegments.Entities;

public sealed class ProcessSegment : BaseEntity
{
    private ProcessSegment() { }
    private ProcessSegment(DateTimeOffset utcNow) : base(utcNow) { }

    public string Name { get; private set; } = string.Empty;

    public static Result<ProcessSegment> Create(string name, DateTimeOffset utcNow)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<ProcessSegment>(ProcessSegmentErrors.InvalidRequestId);
        }

        var processSegment = new ProcessSegment(utcNow)
        {
            Name = name
        };

        return Result.Success(processSegment);
    }
}

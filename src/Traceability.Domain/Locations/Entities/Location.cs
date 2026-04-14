using Traceability.Domain.Locations.Errors;

namespace Traceability.Domain.Locations.Entities;

public sealed class Location : BaseEntity
{
    private Location() { }
    private Location(DateTimeOffset utcNow) : base(utcNow) { }
    public string Name { get; private set; } = string.Empty;

    public static Result<Location> Create(string name, DateTimeOffset utcNow)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Location>(LocationErrors.InvalidRequestId);
        }

        var entity = new Location(utcNow)
        {
            Name = name
        };

        return Result.Success(entity);
    }
}

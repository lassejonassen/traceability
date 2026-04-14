using Traceability.Domain.Materials.Errors;

namespace Traceability.Domain.Materials.Entities;

public sealed class Material : BaseEntity
{
    private Material() { }
    private Material(DateTimeOffset utcNow) : base(utcNow) { }

    public string Name { get; private set; } = string.Empty;

    public static Result<Material> Create(string name, DateTimeOffset utcNow)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Material>(MaterialErrors.InvalidRequestId);
        }

        var entity = new Material(utcNow)
        {
            Name = name
        };

        return Result.Success(entity);
    }
}


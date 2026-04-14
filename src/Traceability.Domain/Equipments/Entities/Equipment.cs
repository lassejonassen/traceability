using Traceability.Domain.Equipments.Errors;

namespace Traceability.Domain.Equipments.Entities;

public sealed class Equipment : BaseEntity
{
    private Equipment() { }
    private Equipment(DateTimeOffset utcNow) : base(utcNow) { }

    public string Name { get; private set; } = string.Empty;

    public static Result<Equipment> Create(string name, DateTimeOffset utcNow)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Equipment>(EquipmentErrors.InvalidRequestId);
        }

        var entity = new Equipment(utcNow)
        {
            Name = name
        };

        return Result.Success(entity);
    }
}

using Traceability.Domain.Equipments.Entities;

namespace Traceability.Domain.Equipments.Errors;

public static class EquipmentErrors
{
    private const string Base = nameof(Equipment);

    public static readonly Error InvalidRequestId
        = new($"{Base}.{nameof(InvalidRequestId)}", "The provided Name is invalid", ErrorType.Validation);
}

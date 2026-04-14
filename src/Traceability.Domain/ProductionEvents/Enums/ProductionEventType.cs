namespace Traceability.Domain.ProductionEvents.Enums;

public enum ProductionEventType
{
    EquipmentActual, // Machine State
    MaterialConsumed,
    MaterialProduced,
    Personnel, // The humans involved (Operator 88, certified)
    ProductionData
}

using Traceability.Domain.Equipments.Entities;
using Traceability.Domain.Locations.Entities;
using Traceability.Domain.Materials.Entities;
using Traceability.Domain.ProductionEvents.DTOs;
using Traceability.Domain.ProductionEvents.Enums;
using Traceability.Domain.ProductionEvents.Errors;
using Traceability.Domain.ProductionRequests.Entities;
using Traceability.Domain.ProductionSchedules.Entities;
using Traceability.Domain.SegmentRequirements.Entities;
using Traceability.Domain.SegmentResponses.Entities;

namespace Traceability.Domain.ProductionEvents.Entities;

public sealed class ProductionEvent : BaseEntity
{
    private ProductionEvent() { }
    private ProductionEvent(DateTimeOffset utcNow) : base(utcNow) { }

    public Guid ProductionScheduleId { get; private set; }
    public ProductionSchedule ProductionSchedule { get; } = null!;
    public Guid ProductionRequestId { get; private set; }
    public ProductionRequest ProductionRequest { get; } = null!;
    public Guid SegmentRequirementId { get; private set; }
    public SegmentRequirement SegmentRequirement { get; } = null!;
    public Guid SegmentResponseId { get; private set; }
    public SegmentResponse SegmentResponse { get; } = null!;
    public ProductionEventType ProductionEventType { get; private set; }
    public string EventId { get; private set; } = string.Empty;
    public Guid MaterialId { get; private set; }
    public Material Material { get; } = null!;
    public Guid EquipmentId { get; private set; }
    public Equipment Equipment { get; } = null!;
    public string Lot { get; private set; } = string.Empty;
    public string SubLot { get; private set; } = string.Empty;
    public string Comment { get; private set; } = string.Empty;
    public Guid LocationId { get; private set; }
    public Location Location { get; } = null!;
    public double Quantity { get; private set; }
    public string UnitOfMeasure { get; private set; } = string.Empty;

    private readonly List<ProductionEventAttribute> _productionEventAttributes = [];
    public IReadOnlyList<ProductionEventAttribute> ProductionEventAttributes => _productionEventAttributes.AsReadOnly();

    public static Result<ProductionEvent> Create(CreateProductionEventDTO Dto, DateTimeOffset utcNow)
    {
        var productionEventType = GetProductionEventType(Dto.ProductionEventType);
        if (productionEventType.IsFailure)
        {
            return Result.Failure<ProductionEvent>(productionEventType.Error);
        }

        var productionEvent = new ProductionEvent(utcNow)
        {
            ProductionScheduleId = Dto.ProductionSchedule,
            ProductionRequestId = Dto.ProductionRequest,
            SegmentRequirementId = Dto.SegmentRequirement,
            SegmentResponseId = Dto.SegmentResponse,
            ProductionEventType = productionEventType.Value,
            EventId = Dto.EventId,
            MaterialId = Dto.Material,
            EquipmentId = Dto.Equipment,
            LocationId = Dto.Location,
            Lot = Dto.Lot,
            SubLot = Dto.SubLot,
            Comment = Dto.Comment,
            Quantity = Dto.Quantity,
            UnitOfMeasure = Dto.UnitOfMeasure
        };

        return Result.Success(productionEvent);
    }

    private static Result<ProductionEventType> GetProductionEventType(string type)
    {
        return type.ToUpper() switch
        {
            "EQUIPMENTACTUAL" => ProductionEventType.EquipmentActual,
            "MATERIALCONSUMED" => ProductionEventType.MaterialConsumed,
            "MATERIALPRODUCED" => ProductionEventType.MaterialProduced,
            "PERSONNEL" => ProductionEventType.Personnel,
            "PRODUCTIONDATA" => ProductionEventType.ProductionData,
            _ => Result.Failure<ProductionEventType>(ProductionEventErrors.InvalidProductionEventType)
        };
    }
}

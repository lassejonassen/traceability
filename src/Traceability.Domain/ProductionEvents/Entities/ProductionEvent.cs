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
    public Guid ParentProductionEventId { get; private set; }
    public ProductionEvent ParentProductionEvent { get; } = null!;
    private readonly List<ProductionEvent> _childProductionEvents = [];
    public IReadOnlyList<ProductionEvent> ChildProductionEvents => _childProductionEvents.AsReadOnly();
    public string Operator { get; private set;  } = string.Empty;
    public DateTime TimeStamp { get; private set; }

    private readonly List<ProductionEventAttribute> _productionEventAttributes = [];
    public IReadOnlyList<ProductionEventAttribute> ProductionEventAttributes => _productionEventAttributes.AsReadOnly();

    public static Result<ProductionEvent> Create(CreateProductionEventDTO dto, DateTimeOffset utcNow)
    {
        var productionEventType = GetProductionEventType(dto.ProductionEventType);
        if (productionEventType.IsFailure)
        {
            return Result.Failure<ProductionEvent>(productionEventType.Error);
        }

        var productionEvent = new ProductionEvent(utcNow)
        {
            ProductionScheduleId = dto.ProductionSchedule,
            ProductionRequestId = dto.ProductionRequest,
            SegmentRequirementId = dto.SegmentRequirement,
            SegmentResponseId = dto.SegmentResponse,
            ProductionEventType = productionEventType.Value,
            EventId = dto.EventId,
            MaterialId = dto.Material,
            EquipmentId = dto.Equipment,
            LocationId = dto.Location,
            Lot = dto.Lot,
            SubLot = dto.SubLot,
            Comment = dto.Comment,
            Quantity = dto.Quantity,
            UnitOfMeasure = dto.UnitOfMeasure,
            ParentProductionEventId = dto.ParentProductionEventId,
            Operator = dto.Operator,
            TimeStamp = dto.TimeStamp,
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

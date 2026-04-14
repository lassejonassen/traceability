namespace Traceability.Application.ProductionEvents.DTOs;

public sealed record ProductionEventTraceDTO
{
    public required string ProductionRequestId { get; init; } = string.Empty;
    public List<ProductionEventNodeDTO> Nodes { get; set; } = [];
}

public sealed record ProductionEventNodeDTO
{
    public required Guid Id { get; init; }
    public required string ProductionScheduleId { get; init; } = string.Empty;
    public required string ProductionRequestId { get; init;  } = string.Empty;
    public required string SegmentRequirementId { get; init;  } = string.Empty;
    public required string SegmentResponseId { get; init;  } = string.Empty;
    public required string EventType { get; init;  } = string.Empty;
    public required string EventId { get; init;  } = string.Empty;
    public required string Material { get; init;  } = string.Empty;
    public required string Equipment { get; init;  } = string.Empty;
    public required string Location { get; init;  } = string.Empty;
    public required string Lot { get; init;  } = string.Empty;
    public required string SubLot { get; init;  } = string.Empty;
    public required string Comment { get; init;  } = string.Empty;
    public required string Quantity { get; init;  } = string.Empty;
    public required string UnitOfMeasure { get; init;  } = string.Empty;

    public List<ProductionEventNodeDTO> Inputs { get; set; } = [];
}
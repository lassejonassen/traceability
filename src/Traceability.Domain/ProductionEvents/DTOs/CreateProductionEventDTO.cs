namespace Traceability.Domain.ProductionEvents.DTOs;

public sealed record CreateProductionEventDTO
{
    public required Guid ProductionSchedule { get; init; }
    public required Guid ProductionRequest { get; init; }
    public required Guid SegmentRequirement { get; init; }
    public required Guid SegmentResponse { get; init; }
    public required string ProductionEventType { get; init; }
    public required string EventId { get; init; }
    public required Guid Material { get; init; }
    public required Guid Equipment { get; init; }
    public required Guid Location { get; init; }
    public required string Lot { get; init; }
    public required string SubLot { get; init; }
    public required string Comment { get; init; }
    public required double Quantity { get; init; }
    public required string UnitOfMeasure { get; init; }
    public required Guid ParentProductionEventId { get; init; }
    public required string Operator { get; init; }
    public required DateTime TimeStamp { get; init; }
}
namespace WebAPI.Contracts;

public sealed record CaptureProductionEventRequest
{
    public string? ProductionSchedule { get; init; }
    public required string ProductionRequest { get; init; }
    public string? SegmentRequirement { get; init; }
    public required string SegmentResponse { get; init; }
    public required string ProductionEventType { get; init; }
    public string? EventId { get; init; }
    public required string Material { get; init; }
    public required string Equipment { get; init; }
    public string? Location { get; init; }
    public string? Lot { get; init; }
    public string? SubLot { get; init; }
    public required double Quantity { get; init; }
    public required string UnitOfMeasure { get; init; }
    public required string ProcessSegment { get; init; }
}

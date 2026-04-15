namespace Traceability.Application.SegmentResponses.DTOs;

public sealed record SegmentResponseDTO
{
    public required Guid Id { get; init; }
    public required string SegmentResponseId { get; init; }
    public required string ProcessSegmentId { get; init; }
}

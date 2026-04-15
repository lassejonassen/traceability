using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Contracts;

public sealed record SegmentResponseDTO
{
    public required Guid Id { get; init; }
    public required string SegmentResponseId { get; init; }
    public required string ProcessSegmentId { get; init; }
}

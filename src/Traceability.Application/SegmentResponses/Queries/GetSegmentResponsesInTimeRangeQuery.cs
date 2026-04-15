using Traceability.Application.SegmentResponses.DTOs;
using Traceability.Domain.SegmentResponses.Repositories;

namespace Traceability.Application.SegmentResponses.Queries;

public sealed record GetSegmentResponsesInTimeRangeQuery(DateTime StartTimeUtc, DateTime EndTimeUtc) : IRequest<IReadOnlyList<SegmentResponseDTO>>;

public sealed class GetSegmentResponsesInTimeRangeQueryHandler(
    ISegmentResponseRepository segmentResponseRepository)
    : IRequestHandler<GetSegmentResponsesInTimeRangeQuery, IReadOnlyList<SegmentResponseDTO>>
{
    public async Task<IReadOnlyList<SegmentResponseDTO>> Handle(GetSegmentResponsesInTimeRangeQuery request, CancellationToken cancellationToken)
    {
        var segmentResponses = await segmentResponseRepository.GetAllInTimeRangeAsync(request.StartTimeUtc, request.EndTimeUtc, cancellationToken);

        var dtos = segmentResponses.Select(x => new SegmentResponseDTO
        {
            Id = x.Id,
            SegmentResponseId = x.SegmentResponseId,
            ProcessSegmentId = x.ProcessSegment.ProcessSegmentId
        }).ToList();

        return dtos;
    }
}
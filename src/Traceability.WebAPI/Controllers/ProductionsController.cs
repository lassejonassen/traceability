using Microsoft.AspNetCore.Mvc;
using Traceability.Application.SegmentResponses.Queries;
using WebAPI.Contracts;

namespace Traceability.WebAPI.Controllers;


[Route("api/productions")]
public class ProductionsController : BaseController
{

    [ProducesResponseType(typeof(IReadOnlyList<SegmentResponseDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet("segment-responses")]
    public async Task<IActionResult> SegmentResponses(DateTime startTimeUtc, DateTime endTimeUtc, CancellationToken cancellationToken)
    {
        var query = new GetSegmentResponsesInTimeRangeQuery(startTimeUtc, endTimeUtc);

        var result = await Mediator.Send(query, cancellationToken);

        if (!result.Any())
        {
            return NoContent();
        }

        var _result = result.Select(x => new SegmentResponseDTO
        {
            Id = x.Id,
            SegmentResponseId = x.SegmentResponseId,
            ProcessSegmentId = x.ProcessSegmentId,
        });

        return Ok(result);
    }
}

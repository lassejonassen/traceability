using Microsoft.AspNetCore.Mvc;
using Traceability.SharedKernel;
using Traceability.SharedKernel.Messaging;

namespace Traceability.WebAPI.Controllers;

[ApiController]
public abstract class BaseController : ControllerBase
{
    private IMediator? _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;

    protected IActionResult HandleFailure(Error error)
    {
        if (error.Type == ErrorType.Failure)
        {
            return Problem();
        }

        if (error.Type == ErrorType.Validation)
        {
            return Problem();
        }

        if (error.Type == ErrorType.NotFound)
        {
            return Problem();
        }

        if (error.Type == ErrorType.Conflict)
        {
            return Problem();
        }

        return Problem();
    }
}

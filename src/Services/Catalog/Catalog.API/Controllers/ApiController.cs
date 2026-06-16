using Asp.Versioning;
using MediatR;

namespace Catalog.API.Controllers;

[ApiVersion("1")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class ApiController : ControllerBase
{
    private IMediator? _mediator;
    
    protected IMediator Mediator =>
        _mediator ??= HttpContext.RequestServices.GetService<IMediator>() 
        ?? throw new InvalidOperationException("Mediator service is not available");
}
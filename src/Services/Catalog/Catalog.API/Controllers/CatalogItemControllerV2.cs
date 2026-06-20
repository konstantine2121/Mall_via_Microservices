using Asp.Versioning;
using Catalog.Application.Queries.CatalogItemQueries;
using Catalog.Application.Responses.CatalogItemResponses;
using Catalog.Domain.Specifications;
using Swashbuckle.AspNetCore.Annotations;

namespace Catalog.API.Controllers;

[ApiVersion("2")]
[ApiExplorerSettings(GroupName = "v2")]
[Route("api/v{version:apiVersion}/CatalogItem")] // Принудительное изменение имени контроллера
public class CatalogItemControllerV2 : ApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(GetCatalogItemsResultV2), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Tags = new [] { "CatalogItemControllerV2" })]
    public async Task<ActionResult<GetCatalogItemsResultV2>> GetCatalogItems(
        [FromQuery] QueryArgs args)
    {
        var query = new GetCatalogItemsQueryV2(args);       
        var result = await Mediator.Send(query);
        return Ok(result);
    }
}
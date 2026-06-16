using Catalog.Application.Queries.CatalogItemQueries;
using Catalog.Application.Responses.CatalogItemResponses;

namespace Catalog.API.Controllers;

public class CatalogItemController : ApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(GetCatalogItemsResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemsResult>> GetCatalogItems()
    {
        var result = await Mediator.Send(new GetCatalogItemsQuery());
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetCatalogItemByIdResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemByIdResult>> GetCatalogItemById(Guid id)
    {
        var result = await Mediator.Send(new GetCatalogItemByIdQuery(id));
        return Ok(result);
    }
}


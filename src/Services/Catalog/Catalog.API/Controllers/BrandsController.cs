using Catalog.Application.Queries.BrandQueries;
using Catalog.Application.Responses.BrandResponses;

namespace Catalog.API.Controllers;

public class BrandsController : ApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(GetBrandsResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetBrandsResult>> GetBrands()
    {
        var result = await Mediator.Send(new GetBrandsQuery());
        return Ok(result);
    }
}
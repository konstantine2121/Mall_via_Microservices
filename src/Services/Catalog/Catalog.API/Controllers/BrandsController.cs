using Catalog.Application.Queries.BrandQueries;
using Catalog.Application.Responses.BrandResponses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BrandsController : ApiController
{
    [HttpGet]
    public async Task<ActionResult<GetBrandsResult>> GetBrands()
    {
        return await Mediator.Send(new GetBrandsQuery());
    }
}
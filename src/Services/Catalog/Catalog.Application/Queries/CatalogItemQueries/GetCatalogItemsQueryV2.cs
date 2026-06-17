using Catalog.Application.Responses.CatalogItemResponses;

namespace Catalog.Application.Queries.CatalogItemQueries;

public record GetCatalogItemsQueryV2(int PageIndex, int PageSize) 
    : IRequest<GetCatalogItemsResultV2>;
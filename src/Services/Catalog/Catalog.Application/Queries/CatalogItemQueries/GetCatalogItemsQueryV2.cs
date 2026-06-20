using Catalog.Application.Responses.CatalogItemResponses;
using Catalog.Domain.Specifications;

namespace Catalog.Application.Queries.CatalogItemQueries;

public record GetCatalogItemsQueryV2(QueryArgs Args) 
    : IRequest<GetCatalogItemsResultV2>;
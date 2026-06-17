using Catalog.Application.Responses.CatalogItemResponses;

namespace Catalog.Application.Queries.CatalogItemQueries;

public record GetCatalogItemByBrandTitleQuery(string BrandTitle) 
    : IRequest<GetCatalogItemByBrandTitleResult>;
using Catalog.Application.Responses.CatalogItemResponses;

namespace Catalog.Application.Queries.CatalogItemQueries;

public record GetCatalogItemByTitleQuery(string Title) 
    : IRequest<GetCatalogItemByTitleResult>;
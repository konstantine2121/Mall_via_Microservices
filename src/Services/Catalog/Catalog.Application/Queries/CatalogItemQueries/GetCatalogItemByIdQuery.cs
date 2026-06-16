using Catalog.Application.Responses.CatalogItemResponses;

namespace Catalog.Application.Queries.CatalogItemQueries;

public record GetCatalogItemByIdQuery(Guid Id)
    : IRequest<GetCatalogItemByIdResult>;
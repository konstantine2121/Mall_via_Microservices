using Catalog.Application.Queries.CatalogItemQueries;
using Catalog.Application.Responses.CatalogItemResponses;

namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class GetCatalogItemByIdQueryHandler (ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<GetCatalogItemByIdQuery,GetCatalogItemByIdResult>
{
    public async Task<GetCatalogItemByIdResult> Handle(GetCatalogItemByIdQuery query, CancellationToken cancellationToken)
    {
        var catalogItem = await catalogItemRepository.GetCatalogItemAsync(query.Id, cancellationToken);
        
        return new GetCatalogItemByIdResult(catalogItem);
    }
}
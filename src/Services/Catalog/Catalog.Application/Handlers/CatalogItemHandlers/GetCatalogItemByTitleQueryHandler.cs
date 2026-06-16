using Catalog.Application.Queries.CatalogItemQueries;
using Catalog.Application.Responses.CatalogItemResponses;

namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class GetCatalogItemByTitleQueryHandler (ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<GetCatalogItemByTitleQuery,GetCatalogItemByTitleResult>
{
    public async Task<GetCatalogItemByTitleResult> Handle(GetCatalogItemByTitleQuery query, CancellationToken cancellationToken)
    {
        var catalogItems = await catalogItemRepository.GetCatalogItemsByTitleAsync(query.Title, cancellationToken);
        
        return new GetCatalogItemByTitleResult(catalogItems);
    }
}
using Catalog.Application.Queries.CatalogItemQueries;
using Catalog.Application.Responses.CatalogItemResponses;

namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class GetCatalogItemByBrandTitleQueryHandler (ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<GetCatalogItemByBrandTitleQuery,GetCatalogItemByBrandTitleResult>
{
    public async Task<GetCatalogItemByBrandTitleResult> Handle(GetCatalogItemByBrandTitleQuery query, CancellationToken cancellationToken)
    {
        var catalogItems = await catalogItemRepository.GetCatalogItemsByBrandAsync(query.BrandTitle, cancellationToken);
        
        return new GetCatalogItemByBrandTitleResult(catalogItems);
    }
}
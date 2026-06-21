using Catalog.Application.Queries.CatalogItemQueries;
using Catalog.Application.Responses.CatalogItemResponses;

namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class GetCatalogItemsQueryHandlerV2 (ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<GetCatalogItemsQueryV2,GetCatalogItemsResultV2>
{
    public async Task<GetCatalogItemsResultV2> Handle(GetCatalogItemsQueryV2 query, CancellationToken cancellationToken)
    {
        var pagination = await catalogItemRepository.GetAllCatalogItemsAsync(query.Args, cancellationToken);
        return new GetCatalogItemsResultV2(pagination);
    }
}
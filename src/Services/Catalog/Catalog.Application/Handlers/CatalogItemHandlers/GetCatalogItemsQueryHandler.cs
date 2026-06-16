using Catalog.Application.Queries.CatalogItemQueries;
using Catalog.Application.Responses.CatalogItemResponses;
using Catalog.Domain.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class GetCatalogItemsQueryHandler (ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<GetCatalogItemsQuery,GetCatalogItemsResult>
{
    public async Task<GetCatalogItemsResult> Handle(GetCatalogItemsQuery request, CancellationToken cancellationToken)
    {
        var catalogItems = await catalogItemRepository.GetAllCatalogItemsAsync(cancellationToken);
        
        return new GetCatalogItemsResult(catalogItems);
    }
}
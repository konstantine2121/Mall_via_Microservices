using Catalog.Application.Commands.CatalogItemCommands;
using Catalog.Application.Responses.CatalogItemResponses;
using Catalog.Domain.Entities;
using Mapster;

namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class CreateCatalogItemHandler (ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<CreateCatalogItemCommand, CreateCatalogItemResult>
{
    public async Task<CreateCatalogItemResult> Handle(CreateCatalogItemCommand command, CancellationToken cancellationToken)
    {
        var catalogItem = command.Adapt<CatalogItem>();
        catalogItem.Id = Guid.NewGuid();
        await catalogItemRepository.CreateCatalogItemAsync(catalogItem, cancellationToken);
        return new CreateCatalogItemResult(catalogItem.Id);
    }
}
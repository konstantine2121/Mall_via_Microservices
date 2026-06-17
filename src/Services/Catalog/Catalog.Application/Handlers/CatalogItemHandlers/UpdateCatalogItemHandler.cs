using Catalog.Application.Commands.CatalogItemCommands;
using Catalog.Application.Responses.CatalogItemResponses;
using Catalog.Domain.Entities;
using Mapster;

namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class UpdateCatalogItemHandler (ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<UpdateCatalogItemCommand, UpdateCatalogItemResult>
{
    public async Task<UpdateCatalogItemResult> Handle(UpdateCatalogItemCommand command,
        CancellationToken cancellationToken)
    {
        var existingItem = await catalogItemRepository.GetCatalogItemAsync(command.Id, cancellationToken);

        if (existingItem is null)
        {
            return new UpdateCatalogItemResult(false);
        }
        
        // TODO: Не забыть про валидацию входящих данных
        
        var catalogItem = command.Adapt<CatalogItem>();
        var isSuccess = await catalogItemRepository.UpdateCatalogItemAsync(catalogItem, cancellationToken);
        return new UpdateCatalogItemResult(isSuccess);
    }
}
using Catalog.Application.Commands.CatalogItemCommands;
using Catalog.Application.Responses.CatalogItemResponses;

namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class DeleteCatalogItemByIdHandler (ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<DeleteCatalogItemByIdCommand, DeleteCatalogItemByIdResult>
{
    public async Task<DeleteCatalogItemByIdResult> Handle(DeleteCatalogItemByIdCommand command, CancellationToken cancellationToken)
    {
        var existingItem = await catalogItemRepository.GetCatalogItemAsync(command.Id, cancellationToken);

        if (existingItem is null)
        {
            return new DeleteCatalogItemByIdResult(false);
        }
        
        var isSuccess = await catalogItemRepository.DeleteCatalogItemAsync(command.Id, cancellationToken);
        return new DeleteCatalogItemByIdResult(isSuccess);
    }
}
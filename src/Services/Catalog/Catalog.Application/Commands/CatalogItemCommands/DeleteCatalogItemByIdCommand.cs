using Catalog.Application.Responses.CatalogItemResponses;

namespace Catalog.Application.Commands.CatalogItemCommands;

public record DeleteCatalogItemByIdCommand(Guid Id) 
    : IRequest<DeleteCatalogItemByIdResult>;
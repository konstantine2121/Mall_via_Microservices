using Catalog.Application.Commands.CatalogItemCommands;
using Catalog.Application.Responses.CatalogItemResponses;
using Catalog.Domain.Entities;
using Mapster;

namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class CreateCatalogItemHandler (ICatalogItemRepository catalogItemRepository,
    IBrandRepository brandRepository,
    ICategoryRepository categoryRepository)
    : IRequestHandler<CreateCatalogItemCommand, CreateCatalogItemResult>
{
    public async Task<CreateCatalogItemResult> Handle(CreateCatalogItemCommand command,
        CancellationToken cancellationToken)
    {
        // Валидация целостности для бренда и категории
        // await ValidateBrandExists(command.Brand, cancellationToken);
        // await ValidateCategoryExists(command.Category, cancellationToken);

        var catalogItem = command.Adapt<CatalogItem>();
        catalogItem.Id = Guid.NewGuid();
        await catalogItemRepository.CreateCatalogItemAsync(catalogItem, cancellationToken);
        return new CreateCatalogItemResult(catalogItem.Id);
    }

    private async Task ValidateCategoryExists(Category? category, CancellationToken cancellationToken)
    {
        // Проверяем Category
        var categoryExists = category != null
                             && (await categoryRepository.GetAllCategoriesAsync(cancellationToken))
                             .Any(c => c.Id == category.Id);

        if (!categoryExists)
        {
            throw new ArgumentException("Указанная категория не существует");
            //Следует использовать свои конкретные типы исключений
        }
    }

    private async Task ValidateBrandExists(Brand? brand, CancellationToken cancellationToken)
    {
        // Проверяем Brand
        var brandExists = brand != null
                          && (await brandRepository.GetAllBrandsAsync(cancellationToken))
                          .Any(b => b.Id == brand.Id);

        if (!brandExists)
        {
            throw new ArgumentException("Указанный бренд не существует");
            //Следует использовать свои конкретные типы исключений
        }
    }
}
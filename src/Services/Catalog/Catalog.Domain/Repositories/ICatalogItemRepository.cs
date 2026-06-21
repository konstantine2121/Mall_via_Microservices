using Catalog.Domain.Specifications;

namespace Catalog.Domain.Repositories;

public interface ICatalogItemRepository
{
    Task<CatalogItem> CreateCatalogItemAsync(CatalogItem item, CancellationToken cancellationToken);
    Task<IEnumerable<CatalogItem>> GetAllCatalogItemsAsync(CancellationToken cancellationToken);
    Task<Pagination<CatalogItem>> GetAllCatalogItemsAsync(QueryArgs args, CancellationToken cancellationToken);
    Task<CatalogItem?> GetCatalogItemAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<CatalogItem>> GetCatalogItemsByTitleAsync(string title, CancellationToken cancellationToken);
    Task<IEnumerable<CatalogItem>> GetCatalogItemsByBrandAsync(string brandTitle, CancellationToken cancellationToken);
    Task<bool> UpdateCatalogItemAsync(CatalogItem item, CancellationToken cancellationToken);
    Task<bool> DeleteCatalogItemAsync(Guid id, CancellationToken cancellationToken);
}
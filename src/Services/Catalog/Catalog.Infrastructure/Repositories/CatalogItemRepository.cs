using Catalog.Domain.Repositories;

namespace Catalog.Infrastructure.Repositories;

public class CatalogItemRepository : ICatalogItemRepository
{
    public Task<CatalogItem> CreateCatalogItemAsync(CatalogItem item, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CatalogItem>> GetAllCatalogItemsAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CatalogItem?> GetCatalogItemAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CatalogItem>> GetCatalogItemsByTitleAsync(string title, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CatalogItem>> GetCatalogItemsByBrandAsync(string brandTitle, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateCatalogItemAsync(CatalogItem item, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteCatalogItemAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
using Catalog.Domain.Repositories;
using Marten;

namespace Catalog.Infrastructure.Repositories;

public class CatalogItemRepository(IDocumentSession session)
    : ICatalogItemRepository
{
    public async Task<CatalogItem> CreateCatalogItemAsync(CatalogItem item, CancellationToken cancellationToken)
    {
        session.Store(item);
        await session.SaveChangesAsync(cancellationToken);
        return item;
    }
    
    public async Task<IEnumerable<CatalogItem>> GetAllCatalogItemsAsync(CancellationToken cancellationToken)
    {
        return  await session.Query<CatalogItem>().ToListAsync(cancellationToken);
    }

    public async Task<CatalogItem?> GetCatalogItemAsync(Guid id, CancellationToken cancellationToken)
    {
        return await session.LoadAsync<CatalogItem>(id, cancellationToken);
    }

    public async Task<IEnumerable<CatalogItem>> GetCatalogItemsByTitleAsync(string title, CancellationToken cancellationToken)
    {
        var items = await session.Query<CatalogItem>()
            .Where(i => i.Title != null && i.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
            .ToListAsync(cancellationToken);
        
        return items;
    }
    
    public async Task<IEnumerable<CatalogItem>> GetCatalogItemsByBrandAsync(string brandTitle, CancellationToken cancellationToken)
    {
        var items = await session.Query<CatalogItem>()
            .Where(i => 
                i.Brand != null 
                && i.Brand.Title != null 
                && i.Brand.Title.Contains(brandTitle, StringComparison.OrdinalIgnoreCase))
            .ToListAsync(cancellationToken);
        
        return items;
    }

    public async Task<bool> UpdateCatalogItemAsync(CatalogItem item, CancellationToken cancellationToken)
    {
        session.Store(item);
        await session.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteCatalogItemAsync(Guid id, CancellationToken cancellationToken)
    {
        session.Delete<CatalogItem>(id);
        await session.SaveChangesAsync(cancellationToken);
        return true;
    }
    
    // Can't call it in Marten's LINQ 
    //private static bool CompareTitles(string? originTitle, string? searchPattern)
    //{
    //    if (string.IsNullOrEmpty(originTitle) ||  string.IsNullOrEmpty(searchPattern))
    //        return false;
    //    
    //    return originTitle.Contains(searchPattern, StringComparison.OrdinalIgnoreCase);
    //}
}
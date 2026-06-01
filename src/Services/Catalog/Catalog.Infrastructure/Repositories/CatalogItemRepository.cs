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
        CatalogItem? item = await session.Query<CatalogItem>()
            .FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
        
        return item;
    }

    public async Task<IEnumerable<CatalogItem>> GetCatalogItemsByTitleAsync(string title, CancellationToken cancellationToken)
    {
        var items = await session.Query<CatalogItem>()
            .Where(i => CompareTitles(i.Title,title))
            .ToListAsync(cancellationToken);
        
        return items;
    }
    
    public async Task<IEnumerable<CatalogItem>> GetCatalogItemsByBrandAsync(string brandTitle, CancellationToken cancellationToken)
    {
        var items = await session.Query<CatalogItem>()
            .Where(i => i.Brand != null && CompareTitles(i.Brand.Title,brandTitle))
            .ToListAsync(cancellationToken);
        
        return items;
    }
 
    public async Task<bool> UpdateCatalogItemAsync(CatalogItem item, CancellationToken cancellationToken)
    {
        bool hasRecord = await HasRecord(item.Id, cancellationToken);
        
        if (hasRecord)
        {
            session.Store(item);
            await session.SaveChangesAsync(cancellationToken);
        }
        
        return hasRecord;
    }

    public async Task<bool> DeleteCatalogItemAsync(Guid id, CancellationToken cancellationToken)
    {
        bool hasRecord = await HasRecord(id, cancellationToken);

        if (hasRecord)
        {
            session.Delete<CatalogItem>(id);
            await session.SaveChangesAsync(cancellationToken);
        }
        return hasRecord;
    }
    
    private async Task<bool> HasRecord(Guid id, CancellationToken cancellationToken)
    {
        return await session.Query<CatalogItem>()
            .AnyAsync(i => i.Id == id, cancellationToken);
    }
    
    private static bool CompareTitles(string? originTitle, string? searchPattern)
    {
        return originTitle == searchPattern;
    }
}
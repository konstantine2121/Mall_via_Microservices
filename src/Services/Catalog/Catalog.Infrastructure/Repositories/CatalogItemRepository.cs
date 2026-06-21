using Catalog.Domain.Repositories;
using Catalog.Domain.Specifications;
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

    public async Task<Pagination<CatalogItem>> GetAllCatalogItemsAsync(QueryArgs args, CancellationToken cancellationToken)
    {
        var allItems = session.Query<CatalogItem>()
            .AsQueryable();
        
        var brandId = args.BrandId;
        if (brandId is not null)
        {
            allItems = allItems.Where(e =>  
                e.Brand != null
                && e.Brand.Id == brandId);
        }
        
        var categoryId = args.CategoryId;
        if (categoryId is not null)
        {
            allItems = allItems.Where(e => 
                e.Category != null 
                && e.Category.Id == categoryId);
        }
        
        var search = args.Search;
        if (!String.IsNullOrWhiteSpace(search))
        {
            allItems = allItems.Where(e => 
                e.Title != null
                && e.Title.Contains(search, StringComparison.OrdinalIgnoreCase));
        }
        
        var sort = args.Search;
        if (!String.IsNullOrWhiteSpace(sort))
        {
            allItems = sort.ToLower() switch
            {
                // asc -  ascending (по возрастанию)
                // desc -  descending (по убыванию)
                "price_desc" => allItems.OrderByDescending(i => i.Price),
                "price_asc" => allItems.OrderBy(i => i.Price),
                "title_desc" => allItems.OrderByDescending(i => i.Title),
                "title_asc" => allItems.OrderBy(i => i.Title),
                _ => allItems
            };
        }
        
        var count  = await allItems.CountAsync(cancellationToken);
        
        var items = await allItems
            .Skip((args.PageIndex - 1) * args.PageSize)
            .Take(args.PageSize)
            .ToListAsync();
        
        var pagination = new Pagination<CatalogItem>(
            PageIndex: args.PageIndex,
            PageSize: args.PageSize,
            TotalCount: count,
            Items: items
        );
        return pagination;
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
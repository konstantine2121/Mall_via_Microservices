using Marten;
using Marten.Schema;

namespace Catalog.Infrastructure.Data.Seed;

public class InitializeDatabaseAsync : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (!await session.Query<Brand>().AnyAsync())
        {
            session.Store<Brand>(InitialData.Brands);
            await session.SaveChangesAsync(cancellation);
        }

        foreach (var category in InitialData.Categories)
        {
            if (!session.Query<Category>().Any(c => c.Id == category.Id))
            {
                session.Store(category);
            }
        }
        
        foreach (var item in InitialData.CatalogItems)
        {
            if (!session.Query<CatalogItem>().Any(i => i.Id == item.Id))
            {
                session.Store(item);
            }
        }
        
        await session.SaveChangesAsync(cancellation);
    }
}
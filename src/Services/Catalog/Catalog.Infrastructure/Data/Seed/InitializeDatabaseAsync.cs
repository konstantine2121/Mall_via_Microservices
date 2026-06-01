using Marten;
using Marten.Schema;

namespace Catalog.Infrastructure.Data.Seed;

public class InitializeDatabaseAsync : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (!await session.Query<Brand>().AnyAsync(cancellation))
        {
            session.Store<Brand>(InitialData.Brands);
            await session.SaveChangesAsync(cancellation);
        }

        foreach (var category in InitialData.Categories)
        {
            if (!await session.Query<Category>().AnyAsync(c => c.Id == category.Id, cancellation))
            {
                session.Store(category);
            }
        }
        
        foreach (var item in InitialData.CatalogItems)
        {
            if (!await session.Query<CatalogItem>().AnyAsync(i => i.Id == item.Id, cancellation))
            {
                session.Store(item);
            }
        }
        
        await session.SaveChangesAsync(cancellation);
    }
}
using Catalog.Domain.Repositories;
using Marten;

namespace Catalog.Infrastructure.Repositories;

public class CategoryRepository(IDocumentSession session)
    : ICategoryRepository
{
    public async Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken)
    {
        return  await session.Query<Category>().ToListAsync(cancellationToken);
    }
}
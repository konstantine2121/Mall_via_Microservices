using Catalog.Domain.Repositories;

namespace Catalog.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
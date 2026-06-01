using Catalog.Domain.Repositories;

namespace Catalog.Infrastructure.Repositories;

public class BrandRepository : IBrandRepository
{
    public Task<IEnumerable<Brand>> GetAllBrandsAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
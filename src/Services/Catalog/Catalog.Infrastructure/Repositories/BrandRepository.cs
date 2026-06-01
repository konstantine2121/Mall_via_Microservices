using Catalog.Domain.Repositories;
using Marten;

namespace Catalog.Infrastructure.Repositories;

public class BrandRepository (IDocumentSession session) : IBrandRepository
{
    public async Task<IEnumerable<Brand>> GetAllBrandsAsync(CancellationToken cancellationToken)
    {
        return  await session.Query<Brand>().ToListAsync(cancellationToken);
    }
}
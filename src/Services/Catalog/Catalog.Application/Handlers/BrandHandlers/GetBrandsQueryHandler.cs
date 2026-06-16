using Catalog.Application.Queries.BrandQueries;
using Catalog.Application.Responses.BrandResponses;

namespace Catalog.Application.Handlers.BrandHandlers;

public class GetBrandsQueryHandler(IBrandRepository brandRepository) 
    : IRequestHandler<GetBrandsQuery, GetBrandsResult> 
{
    public async Task<GetBrandsResult> Handle(GetBrandsQuery query, CancellationToken cancellationToken)
    {
        var brands = await brandRepository.GetAllBrandsAsync(cancellationToken);
        
        return new GetBrandsResult(brands);
    }
}
using Catalog.Application.Queries.BrandQueries;
using Catalog.Application.Responses.BrandResponses;
using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.BrandHandlers;

public class GetBrandsQueryHandler(IBrandRepository brandRepository) 
    : IRequestHandler<GetBrandsQuery, GetBrandsResult> 
{
    public async Task<GetBrandsResult> Handle(GetBrandsQuery query, CancellationToken cancellationToken)
    {
        IEnumerable<Brand> brands = await brandRepository.GetAllBrandsAsync(cancellationToken);
        
        return new GetBrandsResult(brands);
    }
}
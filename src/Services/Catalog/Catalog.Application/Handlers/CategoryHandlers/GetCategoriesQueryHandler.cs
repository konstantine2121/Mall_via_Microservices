using Catalog.Application.Queries.CategoryQueries;
using Catalog.Application.Responses.CategoryResponses;
using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;
using MediatR;

namespace Catalog.Application.Handlers.CategoryHandlers;

public class GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
    : IRequestHandler<GetCategoriesQuery,GetCategoriesResult>
{
    public async Task<GetCategoriesResult> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Category> categories = await categoryRepository.GetAllCategoriesAsync(cancellationToken);
        
        return new GetCategoriesResult(categories);
    }
}
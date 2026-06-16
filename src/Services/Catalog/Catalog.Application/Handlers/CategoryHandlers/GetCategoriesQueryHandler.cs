using Catalog.Application.Queries.CategoryQueries;
using Catalog.Application.Responses.CategoryResponses;

namespace Catalog.Application.Handlers.CategoryHandlers;

public class GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
    : IRequestHandler<GetCategoriesQuery,GetCategoriesResult>
{
    public async Task<GetCategoriesResult> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.GetAllCategoriesAsync(cancellationToken);
        
        return new GetCategoriesResult(categories);
    }
}
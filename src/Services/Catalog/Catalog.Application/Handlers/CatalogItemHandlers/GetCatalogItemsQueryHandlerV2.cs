using Catalog.Application.Queries.CatalogItemQueries;
using Catalog.Application.Responses.CatalogItemResponses;
using Catalog.Domain.Entities;
using Catalog.Domain.Specifications;

namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class GetCatalogItemsQueryHandlerV2 (ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<GetCatalogItemsQueryV2,GetCatalogItemsResultV2>
{
    public async Task<GetCatalogItemsResultV2> Handle(GetCatalogItemsQueryV2 query, CancellationToken cancellationToken)
    {
        var allItems = await catalogItemRepository.GetAllCatalogItemsAsync(cancellationToken);
        
        var brandId = query.Args.BrandId;
        if (brandId is not null)
        {
            allItems = allItems.Where(e => e.Brand?.Id == brandId);
        }
        
        var categoryId = query.Args.CategoryId;
        if (categoryId is not null)
        {
            allItems = allItems.Where(e => e.Category?.Id == categoryId);
        }
        
        var search = query.Args.Search;
        if (!String.IsNullOrWhiteSpace(search))
        {
            allItems = allItems.Where(e => 
                e.Title != null
                && e.Title.Contains(search, StringComparison.OrdinalIgnoreCase));
        }
        
        var sort = query.Args.Search;
        if (!String.IsNullOrWhiteSpace(sort))
        {
            allItems = sort.ToLower() switch
            {
                // asc -  ascending (по возрастанию)
                // desc -  descending (по убыванию)
                "price_desc" => allItems.OrderByDescending(i => i.Price),
                "price_asc" => allItems.OrderBy(i => i.Price),
                "title_desc" => allItems.OrderByDescending(i => i.Title),
                "title_asc" => allItems.OrderBy(i => i.Title),
                _ => allItems
            };
        }
        
        
        var count  = allItems.Count();
        
        var items = allItems
            .Skip((query.Args.PageIndex - 1) * query.Args.PageSize)
            .Take(query.Args.PageSize)
            .ToList();

        var pagination = new Pagination<CatalogItem>(
            PageIndex: query.Args.PageIndex,
            PageSize: query.Args.PageSize,
            TotalCount: count,
            Items: items
        );
        
        return new GetCatalogItemsResultV2(pagination);
    }
}
using Catalog.Application.Responses.CategoryResponses;

namespace Catalog.Application.Queries.CategoryQueries;

public record GetCategoriesQuery :  IRequest<GetCategoriesResult>;
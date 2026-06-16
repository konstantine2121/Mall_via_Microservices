using Catalog.Application.Responses.BrandResponses;

namespace Catalog.Application.Queries.BrandQueries;

public record GetBrandsQuery : IRequest<GetBrandsResult>;
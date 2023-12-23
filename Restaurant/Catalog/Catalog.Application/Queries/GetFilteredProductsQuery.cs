using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetFilteredProductsQuery : IRequest<List<ProductModel>>
    { }
}

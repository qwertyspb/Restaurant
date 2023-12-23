using Catalog.Application.Helpers.SearchHelper;
using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetFilteredProductsQuery : IRequest<Pagination<ProductModel>>
    {
        public SearchFilter SearchFilter { get; set; }
    }
}

using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetProductsByCategoryQuery : IRequest<List<ProductModel>>
    {
        public string CategoryId { get; set; }

        public GetProductsByCategoryQuery(string categoryId)
        {
            CategoryId = categoryId;
        }
    }
}

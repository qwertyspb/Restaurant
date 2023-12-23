using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetCategoryByNameQuery : IRequest<CategoryModel>
    {
        public string Name { get; set; }
    }
}

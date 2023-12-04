using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetAllCategoriesQuery : IRequest<List<CategoryModel>>
    { }
}

using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.IRepositories;
using MediatR;
using MongoDB.Driver;

namespace Catalog.Application.Handlers
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryModel>>
    {
        private readonly ICategoryRepository _repo;

        public GetAllCategoriesHandler(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<CategoryModel>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repo.GetCategories(x => true)
                .ToListAsync(cancellationToken);

            return CatalogMapper.Mapper.Map<List<CategoryModel>>(categories);
        }
    }
}

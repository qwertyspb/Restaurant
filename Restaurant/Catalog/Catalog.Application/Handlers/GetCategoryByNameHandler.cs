using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.IRepositories;
using MediatR;
using MongoDB.Driver;

namespace Catalog.Application.Handlers
{
    public class GetCategoryByNameHandler : IRequestHandler<GetCategoryByNameQuery, CategoryModel>
    {
        private readonly ICategoryRepository _repo;

        public GetCategoryByNameHandler(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<CategoryModel> Handle(GetCategoryByNameQuery request, CancellationToken cancellationToken)
        {
            var category =
                await _repo.GetCategories(x => x.Name.Equals(request.Name))
                    .SingleOrDefaultAsync(cancellationToken) ??
                throw new InvalidOperationException($"Category name={request.Name} is not found");

            return CatalogMapper.Mapper.Map<CategoryModel>(category);
        }
    }
}

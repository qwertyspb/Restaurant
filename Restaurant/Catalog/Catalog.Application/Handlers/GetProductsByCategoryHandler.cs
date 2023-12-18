using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.IRepositories;
using MediatR;
using MongoDB.Driver;

namespace Catalog.Application.Handlers
{
    public class GetProductsByCategoryHandler : IRequestHandler<GetProductsByCategoryQuery, List<ProductModel>>
    {
        private readonly IProductRepository _repo;

        public GetProductsByCategoryHandler(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ProductModel>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            var products = (await _repo.GetProducts(x => x.Category.Id == request.CategoryId))
                .ToListAsync(cancellationToken);

            return CatalogMapper.Mapper.Map<List<ProductModel>>(products);
        }
    }
}

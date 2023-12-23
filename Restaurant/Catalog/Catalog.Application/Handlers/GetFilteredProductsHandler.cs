using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.IRepositories;
using MediatR;
using MongoDB.Driver;

namespace Catalog.Application.Handlers
{
    public class GetFilteredProductsHandler : IRequestHandler<GetFilteredProductsQuery, List<ProductModel>>
    {
        private readonly IProductRepository _repo;

        public GetFilteredProductsHandler(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ProductModel>> Handle(GetFilteredProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repo.GetProducts(x => !x.IsDeleted)
                .ToListAsync(cancellationToken);

            return CatalogMapper.Mapper.Map<List<ProductModel>>(products);
        }
    }
}

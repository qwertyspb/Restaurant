using Catalog.Application.Helpers.SearchHelper;
using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.IRepositories;
using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Application.Handlers
{
    public class GetFilteredProductsHandler : IRequestHandler<GetFilteredProductsQuery, Pagination<ProductModel>>
    {
        private readonly IProductRepository _repo;
        private CancellationToken Token;

        public GetFilteredProductsHandler(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<Pagination<ProductModel>> Handle(GetFilteredProductsQuery request, CancellationToken cancellationToken)
        {
            Token = cancellationToken;
            var requestFilter = request.SearchFilter;

            var builder = Builders<Product>.Filter;
            var filter = builder.Eq(x => x.IsDeleted, false);

            if (!string.IsNullOrEmpty(requestFilter.Search))
            {
                var searchFilter = builder.Regex(x => x.Name, new BsonRegularExpression(requestFilter.Search));
                filter &= searchFilter;
            }

            if (!string.IsNullOrEmpty(request.SearchFilter.CategoryId))
            {
                var categoryFilter = builder.Eq(x => x.Category.Id, requestFilter.CategoryId);
                filter &= categoryFilter;
            }

            var data = await DataFilter(requestFilter, filter);

            var result = new Pagination<Product>
            {
                PageSize = requestFilter.PageSize,
                PageIndex = requestFilter.PageIndex,
                Data = data,
                Count = await _repo.GetProducts(x => !x.IsDeleted).CountDocumentsAsync(Token)
            };

            return CatalogMapper.Mapper.Map<Pagination<ProductModel>>(result);
        }

        private async Task<IReadOnlyList<Product>> DataFilter(SearchFilter requestFilter, FilterDefinition<Product> filter)
        {
            var products = _repo.GetProducts(filter);

            var data = requestFilter.Sorting switch
            {
                "priceAsc" => products.Sort(Builders<Product>.Sort.Ascending("Price")),
                "priceDesc" => products.Sort(Builders<Product>.Sort.Descending("Price")),
                _ => products.Sort(Builders<Product>.Sort.Ascending("Name"))
            };

            return await data.Skip(requestFilter.PageSize * (requestFilter.PageIndex - 1))
                .Limit(requestFilter.PageSize)
                .ToListAsync(Token);
        }
    }
}

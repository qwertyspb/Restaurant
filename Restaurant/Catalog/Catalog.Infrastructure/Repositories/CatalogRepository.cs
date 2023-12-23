using Catalog.Core.Entities;
using Catalog.Core.IRepositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Catalog.Infrastructure.Repositories
{
    public class CatalogRepository : IProductRepository, ICategoryRepository
    {
        private readonly ICatalogContext _ctx;

        public CatalogRepository(ICatalogContext ctx)
        {
            _ctx = ctx;
        }

        #region Product

        public Task CreateProduct(Product product)
            => _ctx.Products.InsertOneAsync(product);

        public Task<Product> GetProductById(string id)
            => _ctx.Products.Find(x => x.Id == id).SingleOrDefaultAsync();

        public IFindFluent<Product, Product> GetProducts(Expression<Func<Product, bool>> condition)
            => _ctx.Products.Find(condition);

        public async Task<bool> UpdateProduct(Product product)
        {
            var result = await _ctx.Products.ReplaceOneAsync(x => x.Id == product.Id, product);
            return result.IsAcknowledged;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var result = await _ctx.Products.DeleteOneAsync(x => x.Id == id);
            return result.IsAcknowledged;
        }

        #endregion


        #region Category

        public Task CreateCategory(Category category)
            => _ctx.Categories.InsertOneAsync(category);

        public Task<Category> GetCategoryById(string id)
            => _ctx.Categories.Find(x => x.Id == id).SingleOrDefaultAsync();

        public IFindFluent<Category, Category> GetCategories(Expression<Func<Category, bool>> condition)
            => _ctx.Categories.Find(condition);
        
        public async Task<bool> UpdateCategory(Category category)
        {
            var result = await _ctx.Categories.ReplaceOneAsync(x => x.Id == category.Id, category);
            return result.IsAcknowledged;
        }

        public async Task<bool> DeleteCategory(string id)
        {
            var result = await _ctx.Categories.DeleteOneAsync(x => x.Id == id);
            return result.IsAcknowledged;
        }

        #endregion
    }
}

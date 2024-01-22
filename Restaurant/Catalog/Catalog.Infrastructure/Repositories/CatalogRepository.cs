using Catalog.Core.Entities;
using Catalog.Core.IRepositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Catalog.Infrastructure.Repositories
{
    public class CatalogRepository : IProductRepository, ICategoryRepository, ITableRepository
    {
        private readonly ICatalogContext _ctx;

        public CatalogRepository(ICatalogContext ctx)
        {
            _ctx = ctx;
        }

        #region Product

        public async Task CreateProduct(Product product)
        {
            product.CreatedOn = DateTime.Now;
            await _ctx.Products.InsertOneAsync(product);
        }

        public Task<Product> GetProductById(string id)
            => _ctx.Products.Find(x => x.Id == id).SingleOrDefaultAsync();

        public IFindFluent<Product, Product> GetProducts(Expression<Func<Product, bool>> condition)
            => _ctx.Products.Find(condition);

        public IFindFluent<Product, Product> GetProducts(FilterDefinition<Product> filter)
            => _ctx.Products.Find(filter);

        public async Task UpdateProduct(Product product)
        {
            product.ModifiedOn = DateTime.Now;
            await _ctx.Products.ReplaceOneAsync(x => x.Id == product.Id, product);
        }

        public Task DeleteProduct(string id)
           => _ctx.Products.DeleteOneAsync(x => x.Id == id);

        #endregion


        #region Category

        public async Task CreateCategory(Category category)
        {
            category.CreatedOn = DateTime.Now;
            await _ctx.Categories.InsertOneAsync(category);
        }

        public Task<Category> GetCategoryById(string id)
            => _ctx.Categories.Find(x => x.Id == id).SingleOrDefaultAsync();

        public IFindFluent<Category, Category> GetCategories(Expression<Func<Category, bool>> condition)
            => _ctx.Categories.Find(condition);
        
        public async Task UpdateCategory(Category category)
        {
            category.ModifiedOn = DateTime.Now;
            await _ctx.Categories.ReplaceOneAsync(x => x.Id == category.Id, category);
        }

        public Task DeleteCategory(string id)
            => _ctx.Categories.DeleteOneAsync(x => x.Id == id);

        #endregion

        #region Table

        public async Task CreateTable(Table table)
        {
            table.CreatedOn = DateTime.Now;
            await _ctx.Tables.InsertOneAsync(table);
        }

        public IFindFluent<Table, Table> GetTables(Expression<Func<Table, bool>> condition)
            => _ctx.Tables.Find(condition);

        public async Task UpdateTable(Table table)
        {
            table.ModifiedOn = DateTime.Now;
            await _ctx.Tables.ReplaceOneAsync(x => x.Id == table.Id, table);
        }

        public Task DeleteTable(string id)
            => _ctx.Tables.DeleteOneAsync(x => x.Id == id);

        #endregion
    }
}

using System.Linq.Expressions;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Core.IRepositories
{
    public interface IProductRepository
    {
        Task CreateProduct(Product product);
        Task<Product> GetProductById(string id);
        Task<IFindFluent<Product, Product>> GetProducts(Expression<Func<Product, bool>> condition);
        Task<bool> UpdateProduct(Product product); 
        Task<bool> DeleteProduct(string id);
    }
}

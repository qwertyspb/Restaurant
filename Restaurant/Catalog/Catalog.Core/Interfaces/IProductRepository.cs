using Catalog.Core.Entities;
using System.Linq.Expressions;

namespace Catalog.Core.Interfaces
{
    public interface IProductRepository
    {
        Task CreateProduct(Product product);
        Task<Product> GetProduct(string id);
        Task<Product> GetProduct(Expression<Func<Product,bool>> condition);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Product>> GetAllProducts(Expression<Func<Product, bool>> condition);
        Task UpdateProduct(Product product); 
        Task DeleteProduct(string id);
    }
}

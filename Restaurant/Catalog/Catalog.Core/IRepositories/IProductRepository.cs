using System.Linq.Expressions;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Core.IRepositories
{
    public interface IProductRepository
    {
        Task CreateProduct(Product product);
        Task<Product> GetProductById(string id);
        IFindFluent<Product, Product> GetProducts(Expression<Func<Product, bool>> condition);
        Task UpdateProduct(Product product); 
        Task DeleteProduct(string id);
    }
}

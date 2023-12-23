using System.Linq.Expressions;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Core.IRepositories
{
    public interface ICategoryRepository
    {
        Task CreateCategory(Category category);
        Task<Category> GetCategoryById(string id);
        IFindFluent<Category, Category> GetCategories(Expression<Func<Category, bool>> condition);
        Task<bool> UpdateCategory(Category category);
        Task<bool> DeleteCategory(string id);
    }
}

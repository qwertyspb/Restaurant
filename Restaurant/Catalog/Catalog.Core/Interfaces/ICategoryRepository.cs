using Catalog.Core.Entities;
using System.Linq.Expressions;

namespace Catalog.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task CreateCategory(Category category);
        Task<Category> GetCategory(string id);
        Task<Category> GetCategory(Expression<Func<Category, bool>> condition);
        Task UpdateCategory(Category category);
        Task DeleteCategory(string id);
    }
}

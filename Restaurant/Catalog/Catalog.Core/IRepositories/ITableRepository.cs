using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Catalog.Core.IRepositories;

public interface ITableRepository
{
    Task CreateTable(Table table);
    IFindFluent<Table, Table> GetTables(Expression<Func<Table, bool>> condition);
    Task UpdateTable(Table table);
    Task DeleteTable(string id);
}
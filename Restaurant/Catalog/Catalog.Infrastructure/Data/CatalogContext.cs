using System.Linq.Expressions;
using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }
        public IMongoCollection<Category> Categories { get; }

        public CatalogContext(IConfiguration configuration)
        {
            const string dbs = "DatabaseSettings:";

            var client = new MongoClient(configuration.GetValue<string>($"{dbs}ConnectionString"));
            var db = client.GetDatabase(configuration.GetValue<string>($"{dbs}DatabaseName"));

            Products = db.GetCollection<Product>(configuration.GetValue<string>($"{dbs}ProductsCollection"));
            Categories = db.GetCollection<Category>(configuration.GetValue<string>($"{dbs}CategoriesCollection"));

            CreateUniqueFields(Categories, x => x.Name);

            SeedingFactory.Seed(Products, "products.json");
            SeedingFactory.Seed(Categories, "categories.json");
        }

        private static void CreateUniqueFields<T>(IMongoCollection<T> collection, params Expression<Func<T, object>>[] fields)
        {
            foreach (var field in fields)
            {
                var yourFieldIndex = Builders<T>.IndexKeys.Ascending(field);
                var indexOptions = new CreateIndexOptions { Unique = true };
                var modelIndex = new CreateIndexModel<T>(yourFieldIndex, indexOptions);
                collection.Indexes.CreateOne(modelIndex);
            }
        }
    }
}

using MongoDB.Driver;
using Newtonsoft.Json;

namespace Catalog.Infrastructure.Data
{
    public class SeedingFactory
    {
        public static void Seed<T>(IMongoCollection<T> collection, string fileName) where T : class
        {
            var path = Path.Combine("Data", "SeedData", fileName);
            var any = collection.Find(x => true).Any();

            if (!any)
            {
                var data = File.ReadAllText(path);
                var entities = JsonConvert.DeserializeObject<IEnumerable<T>>(data);

                if (entities is not null)
                    collection.InsertMany(entities);
            }
        }
    }
}

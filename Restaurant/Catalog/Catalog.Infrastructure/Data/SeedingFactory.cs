using Catalog.Core.Entities;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace Catalog.Infrastructure.Data
{
    public class SeedingFactory
    {
        private static readonly string ImagesPath = Path.Combine("Data", "SeedData", "Images");
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

        public static void SeedProducts(IMongoCollection<Product> collection, string fileName)
        {
            var path = Path.Combine("Data", "SeedData", fileName);
            var any = collection.Find(x => true).Any();

            if (any)
                return;

            var data = File.ReadAllText(path);
            var products = JsonConvert.DeserializeObject<List<Product>>(data);

            if (products is null)
                return;

            var images = GetImages("productImages.json");

            foreach (var p in products)
            {
                var image = images.FirstOrDefault(x => x.EntityId == p.Id);

                if (image is null)
                {
                    p.Image = string.Empty;
                    continue;
                }

                p.Image = ImagesPath + image.Url;
            }

            collection.InsertMany(products);
        }

        private static List<Image> GetImages(string fileName)
        {
            var path = Path.Combine(ImagesPath, fileName);
            var data = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<Image>>(data);
        }

        private class Image
        {
            public string EntityId { get; set; }
            public string Url { get; set; }
        }
    }
}

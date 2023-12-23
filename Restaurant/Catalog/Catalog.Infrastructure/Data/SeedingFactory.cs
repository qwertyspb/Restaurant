using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace Catalog.Infrastructure.Data
{
    public class SeedingFactory
    {
        private static readonly string ImagesPath = Path.Combine("Data", "SeedData", "Images");
        public static void Seed<T>(IMongoCollection<T> collection, string fileName) where T : BaseEntity
        {
            var path = Path.Combine("Data", "SeedData", fileName);
            var any = collection.Find(x => true).Any();

            if (any) 
                return;

            var data = File.ReadAllText(path);
            var entities = JsonConvert.DeserializeObject<List<T>>(data);

            if (entities is null)
                return;
                
            SetCreatedOn(entities);

            collection.InsertMany(entities);
        }

        public static void SeedWithImage<T>(IMongoCollection<T> collection, string fileName, string imagesFileName)
            where T : BaseEntity, IHaveImage
        {
            var path = Path.Combine("Data", "SeedData", fileName);
            var any = collection.Find(x => true).Any();

            if (any)
                return;

            var data = File.ReadAllText(path);
            var entities = JsonConvert.DeserializeObject<List<T>>(data);

            if (entities is null)
                return;

            SetCreatedOn(entities);

            if (!string.IsNullOrEmpty(imagesFileName))
                SetImages(entities, imagesFileName);

            collection.InsertMany(entities);
        }


        private static void SetCreatedOn<T>(List<T> entities) where T : BaseEntity
            => entities.ForEach(x => x.CreatedOn = DateTime.Now);

        private static void SetImages<T>(List<T> entities, string imagesFileName) where T : BaseEntity, IHaveImage
        {
            var images = GetImages(imagesFileName);

            foreach (var e in entities)
            {
                var image = images.FirstOrDefault(x => x.EntityId == e.Id);

                if (image is null)
                {
                    e.Image = string.Empty;
                    continue;
                }

                e.Image = ImagesPath + image.Url;
            }
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

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Catalog.Application.Responses
{
    public class ProductModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }
    }
}

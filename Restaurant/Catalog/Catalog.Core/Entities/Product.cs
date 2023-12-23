using Catalog.Core.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Entities
{
    public class Product : BaseEntity, IHaveImage
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }

        public bool IsDeleted { get; set; }

        public Category Category { get; set; }
    }
}

using MediatR;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Application.Commands
{
    public class CreateProductCommand : IRequest
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public string CategoryId { get; set; }
    }
}

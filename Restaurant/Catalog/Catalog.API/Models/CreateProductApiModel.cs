using MediatR;

namespace Catalog.API.Models
{
    public class CreateProductApiModel : IRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public string CategoryId { get; set; }
    }
}

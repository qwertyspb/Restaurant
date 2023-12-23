using MediatR;

namespace Catalog.API.Models
{
    public class UpdateProductApiModel : IRequest
    {
        public string ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public string CategoryId { get; set; }
    }
}

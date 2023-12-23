using MediatR;

namespace Catalog.Application.Commands
{
    public class UpdateProductCommand : IRequest
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string CategoryId { get; set; }
    }
}

using MediatR;

namespace Catalog.Application.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public string ProductId { get; set; }
    }
}

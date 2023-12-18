using Catalog.Application.Commands;
using Catalog.Application.Extensions;
using Catalog.Core.IRepositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _repo;

        public DeleteProductHandler(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repo.GetProductById(request.ProductId) ??
                          throw new InvalidOperationException($"Product id={request.ProductId} is not found");

            product = new UpdateProductBuilder(product)
                .IsDeleted(true)
                .Build();

            await _repo.UpdateProduct(product);
        }
    }
}

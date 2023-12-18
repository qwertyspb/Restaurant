using Catalog.Application.Commands;
using Catalog.Application.Extensions;
using Catalog.Core.IRepositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateProductHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductById(request.ProductId) ??
                          throw new InvalidOperationException($"Product id={request.ProductId} is not found");

            var builder = new UpdateProductBuilder(product)
                .Name(request.Name)
                .Description(request.Description)
                .Image(request.Image)
                .Price(request.Price);

            if (!string.IsNullOrEmpty(request.CategoryId))
            {
                var category = await _categoryRepository.GetCategoryById(request.CategoryId) ??
                               throw new InvalidOperationException($"Category id={request.CategoryId} is not found");

                builder.Category(category);
            }

            product = builder.Build();

            await _productRepository.UpdateProduct(product);
        }
    }
}

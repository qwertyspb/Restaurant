using Catalog.Application.Commands;
using Catalog.Core.Entities;
using Catalog.Core.IRepositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CreateProductHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryById(request.CategoryId) ??
                           throw new InvalidOperationException($"Product id={request.CategoryId} is not found");

            var product = new Product
            {
                Category = category,
                Description = request.Description,
                Image = request.Image,
                Name = request.Name,
                Price = request.Price
            };

            await _productRepository.CreateProduct(product);
        }
    }
}

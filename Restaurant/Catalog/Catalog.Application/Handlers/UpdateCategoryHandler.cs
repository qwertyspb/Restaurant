using Catalog.Application.Commands;
using Catalog.Core.IRepositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _repo;

        public UpdateCategoryHandler(ICategoryRepository repo)
        {
            _repo = repo;
        }
        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repo.GetCategoryById(request.CategoryId) ??
                          throw new InvalidOperationException($"Category id={request.CategoryId} is not found");

            category.Name = request.Name;

            await _repo.UpdateCategory(category);
        }
    }
}

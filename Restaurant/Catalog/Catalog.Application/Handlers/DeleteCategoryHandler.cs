using Catalog.Application.Commands;
using Catalog.Core.IRepositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _repo;

        public DeleteCategoryHandler(ICategoryRepository repo)
        {
            _repo = repo;
        }
        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repo.GetCategoryById(request.CategoryId) ??
                           throw new InvalidOperationException($"Category id={request.CategoryId} is not found");

            await _repo.DeleteCategory(category.Id);
        }
    }
}

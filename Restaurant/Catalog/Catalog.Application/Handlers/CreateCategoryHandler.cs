using Catalog.Application.Commands;
using Catalog.Core.Entities;
using Catalog.Core.IRepositories;
using MediatR;
using MongoDB.Driver;

namespace Catalog.Application.Handlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _repo;

        public CreateCategoryHandler(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repo.GetCategories(x => x.Name.Equals(request.Name))
                .ToListAsync(cancellationToken);

            if (existing.Any())
            {
                var ids = existing.Select(x => x.Id)
                    .ToList();

                throw new InvalidOperationException(
                    $"Category name={request.Name} already exists. CategoryId={string.Join(",", ids)}");
            }

            var category = new Category
            {
                Name = request.Name
            };

            await _repo.CreateCategory(category);
        }
    }
}

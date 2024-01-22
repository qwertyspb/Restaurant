using Catalog.Application.Commands;
using Catalog.Core.IRepositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class DeleteTableHandler : IRequestHandler<DeleteTableCommand>
{
    private readonly ITableRepository _repo;

    public DeleteTableHandler(ITableRepository repo)
    {
        _repo = repo;
    }

    public Task Handle(DeleteTableCommand request, CancellationToken cancellationToken)
        => _repo.DeleteTable(request.TableId);
}
using Catalog.Application.Commands;
using Catalog.Core.IRepositories;
using MediatR;
using MongoDB.Driver;

namespace Catalog.Application.Handlers;

public class DeleteTableHandler : IRequestHandler<DeleteTableCommand>
{
    private readonly ITableRepository _repo;

    public DeleteTableHandler(ITableRepository repo)
    {
        _repo = repo;
    }

    public async Task Handle(DeleteTableCommand request, CancellationToken cancellationToken)
    {
        var table = await _repo.GetTables(x => x.Id.Equals(request.TableId))
                        .FirstOrDefaultAsync(cancellationToken) ??
                       throw new InvalidOperationException($"Category id={request.TableId} is not found.");

        await _repo.DeleteTable(request.TableId);
    }
}
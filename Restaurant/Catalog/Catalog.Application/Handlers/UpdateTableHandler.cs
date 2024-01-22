using Catalog.Application.Commands;
using Catalog.Core.IRepositories;
using MediatR;
using MongoDB.Driver;

namespace Catalog.Application.Handlers;

public class UpdateTableHandler : IRequestHandler<UpdateTableCommand>
{
    private readonly ITableRepository _repo;

    public UpdateTableHandler(ITableRepository repo)
    {
        _repo = repo;
    }
    public async Task Handle(UpdateTableCommand request, CancellationToken cancellationToken)
    {
        var table = await _repo.GetTables(x => x.Id == request.TableId).SingleOrDefaultAsync(cancellationToken) ??
                    throw new InvalidOperationException($"Table id={request.TableId} is not found");

        table.Amount = request.Amount;
        table.Capacity = request.Capacity;

        await _repo.UpdateTable(table);
    }
}
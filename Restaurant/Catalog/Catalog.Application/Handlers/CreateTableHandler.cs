using Catalog.Application.Commands;
using Catalog.Core.Entities;
using Catalog.Core.IRepositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class CreateTableHandler : IRequestHandler<CreateTableCommand>
{
    private readonly ITableRepository _repo;

    public CreateTableHandler(ITableRepository repo)
    {
        _repo = repo;
    }
    public async Task Handle(CreateTableCommand request, CancellationToken cancellationToken)
    {
        var table = new Table
        {
            Capacity = request.Capacity,
            Amount = request.Amount
        };

        await _repo.CreateTable(table);
    }
}
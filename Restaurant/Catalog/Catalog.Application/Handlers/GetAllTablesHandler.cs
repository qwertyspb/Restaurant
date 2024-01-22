using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.IRepositories;
using MediatR;
using MongoDB.Driver;

namespace Catalog.Application.Handlers;

public class GetAllTablesHandler : IRequestHandler<GetAllTablesQuery, List<TableModel>>
{
    private readonly ITableRepository _repo;

    public GetAllTablesHandler(ITableRepository repo)
    {
        _repo = repo;
    }
    public async Task<List<TableModel>> Handle(GetAllTablesQuery request, CancellationToken cancellationToken)
    {
        var tables = await _repo.GetTables(x => true).ToListAsync(cancellationToken);

        return CatalogMapper.Mapper.Map<List<TableModel>>(tables);
    }
}
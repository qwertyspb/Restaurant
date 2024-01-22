using Catalog.API.Mappers;
using Catalog.API.Models;
using Catalog.Application.Commands;
using Catalog.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers;

public class TableController : ApiController
{
    private readonly IMediator _mediator;

    public TableController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("[action]")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateTable(CreateTableApiModel model, CancellationToken token)
    {
        var command = new CreateTableCommand
        {
            Amount = model.Amount,
            Capacity = model.Capacity
        };

        await _mediator.Send(command, token);

        return Ok();
    }

    [HttpGet]
    [Route("[action]")]
    [ProducesResponseType(typeof(List<TableApiModel>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllTables(CancellationToken token)
    {
        var tables = await _mediator.Send(new GetAllTablesQuery(), token);

        return Ok(ApiCatalogMapper.Mapper.Map<List<TableApiModel>>(tables));
    }

    [HttpPatch]
    [Route("[action]")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateTable(UpdateTableApiModel model, CancellationToken token)
    {
        var command = new UpdateTableCommand
        {
            TableId = model.TableId,
            Capacity = model.Capacity,
            Amount = model.Amount
        };

        await _mediator.Send(command, token); 
        
        return Ok();
    }

    [HttpDelete]
    [Route("[action]")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteTable(string tableId, CancellationToken token)
    {
        var command = new DeleteTableCommand { TableId = tableId };
        await _mediator.Send(command, token);

        return Ok();
    }
}
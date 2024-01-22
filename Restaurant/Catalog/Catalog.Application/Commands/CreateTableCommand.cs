using MediatR;

namespace Catalog.Application.Commands;

public class CreateTableCommand : IRequest
{
    public int Capacity { get; set; }
    public int Amount { get; set; }
}
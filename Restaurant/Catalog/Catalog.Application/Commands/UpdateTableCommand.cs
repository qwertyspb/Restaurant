using MediatR;

namespace Catalog.Application.Commands;

public class UpdateTableCommand : IRequest
{
    public string TableId { get; set; }
    public int Capacity { get; set; }
    public int Amount { get; set; }
}
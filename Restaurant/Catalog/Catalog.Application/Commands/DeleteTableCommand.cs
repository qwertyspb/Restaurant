using MediatR;

namespace Catalog.Application.Commands;

public class DeleteTableCommand : IRequest
{
    public string TableId { get; set; }
}
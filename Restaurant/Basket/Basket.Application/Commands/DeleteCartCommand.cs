using MediatR;

namespace Basket.Application.Commands;

public class DeleteCartCommand : IRequest
{
    public string UserName { get; set; }
}
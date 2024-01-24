using MediatR;

namespace Basket.Application.Commands;

public class DeleteCartCommand : UserNameBasedRequest, IRequest
{
}
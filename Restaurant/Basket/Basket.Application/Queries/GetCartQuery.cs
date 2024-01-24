using Basket.Application.Commands;
using Basket.Application.Responses;
using MediatR;

namespace Basket.Application.Queries;

public class GetCartQuery : UserNameBasedRequest, IRequest<CartResponse>
{
}
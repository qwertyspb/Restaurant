using Basket.Application.Responses;
using MediatR;

namespace Basket.Application.Queries;

public class GetCartQuery : IRequest<CartResponse>
{
    public string UserName { get; set; }
}
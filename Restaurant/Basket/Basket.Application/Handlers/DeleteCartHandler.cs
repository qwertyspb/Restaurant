using Basket.Application.Commands;
using Basket.Core.IRepositories;
using MediatR;

namespace Basket.Application.Handlers;

public class DeleteCartHandler : IRequestHandler<DeleteCartCommand>
{
    private readonly ICartRepository _repo;

    public DeleteCartHandler(ICartRepository repo)
    {
        _repo = repo;
    }

    public Task Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        => _repo.DeleteCart(request.UserName);
}
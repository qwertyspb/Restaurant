using Basket.Application.Commands;
using Basket.Application.Extensions;
using Basket.Application.Validators;
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

    public async Task Handle(DeleteCartCommand request, CancellationToken cancellationToken)
    {
        request.Validate(new UserNameValidator<DeleteCartCommand>());
        await _repo.DeleteCart(request.UserName);
    }
}
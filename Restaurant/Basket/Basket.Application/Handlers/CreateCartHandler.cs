using Basket.Application.Commands;
using Basket.Application.Extensions;
using Basket.Application.Responses;
using Basket.Application.Validators;
using Basket.Core.Entities;
using Basket.Core.IRepositories;
using MediatR;

namespace Basket.Application.Handlers;

public class CreateCartHandler : IRequestHandler<CreateCartCommand, CreateCartResponse>
{
    private readonly ICartRepository _repo;

    public CreateCartHandler(ICartRepository repo)
    {
        _repo = repo;
    }

    public async Task<CreateCartResponse> Handle(CreateCartCommand request, CancellationToken cancellationToken)
    {
        request.Validate(new CreateCartCommandValidator());

        var cart = await _repo.GetCart(request.UserName)
                   ?? new Cart { UserName = request.UserName };

        // TODO: get all appropriate tables from Catalog via messaging, choose table id or return Fail status
        //var response = await AskForTables(request.BookingStartDate, request.BookingDuration, request.VisitorsAmount);

        //if (string.IsNullOrEmpty(response.tableId))
        //    return new CreateCartResponse { IsSuccess = false, ErrorMessage = response.Message };

        var tableId = "65ae40d7bc621e495748b8e7";

        cart.TableItem = new TableItem
        {
            TableId = tableId,
            VisitorsAmount = request.VisitorsAmount,
            BookingDuration = request.BookingDuration,
            BookingStartDate = request.BookingStartDate
        };

        await _repo.CreateOrUpdateCart(cart, TimeSpan.FromDays(1));

        return new CreateCartResponse
        {
            IsSuccess = true,
            Message = string.Empty
        };
    }
}
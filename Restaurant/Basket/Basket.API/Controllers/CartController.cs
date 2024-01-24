using Basket.API.Mappers;
using Basket.API.Models;
using Basket.Application.Commands;
using Basket.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers;

public class CartController : ApiController
{
    private readonly IMediator _mediator;

    public CartController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("[action]")]
    [ProducesResponseType(typeof(CreateCartApiResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateOrUpdateCart(CreateCartApiModel model, CancellationToken token)
    {
        var command = new CreateCartCommand
        {
            UserName = model.UserName,
            BookingStartDate = model.BookingStartDate,
            BookingDuration = TimeSpan.FromHours(model.BookingDurationInHours),
            VisitorsAmount = model.VisitorsAmount
        };

        var result = await _mediator.Send(command, token);

        var apiResult = ApiBasketMapper.Mapper.Map<CreateCartApiResponse>(result);

        return Ok(apiResult);
    }

    [HttpPatch]
    [Route("[action]")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddProductsToCart(AddProductsToCartApiModel model, CancellationToken token)
    {
        var command = ApiBasketMapper.Mapper.Map<AddProductsToCartCommand>(model);

        await _mediator.Send(command, token);

        return Ok();
    }

    [HttpGet]
    [Route("[action]/{userName}")]
    [ProducesResponseType(typeof(GetCartApiModel), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCart(string userName, CancellationToken token)
    {
        var cart = await _mediator.Send(new GetCartQuery { UserName = userName }, token);

        if (cart is null)
            return BadRequest("No cart was found.");

        return Ok(ApiBasketMapper.Mapper.Map<GetCartApiModel>(cart));
    }

    [HttpDelete]
    [Route("[action]")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> ClearCart(string userName, CancellationToken token)
    {
        await _mediator.Send(new DeleteCartCommand { UserName = userName }, token);
        return Ok();
    }
}
using Basket.API.Mappers;
using Basket.API.Models;
using Basket.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Basket.Application.Queries;

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
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateOrUpdateCart(CreateOrUpdateCartApiModel model, CancellationToken token)
    {
        var command = ApiBasketMapper.Mapper.Map<CreateOrUpdateCartCommand>(model);

        await _mediator.Send(command, token);

        return Ok();
    }

    [HttpGet]
    [Route("[action]")]
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
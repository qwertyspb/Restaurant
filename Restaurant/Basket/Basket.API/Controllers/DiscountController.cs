using Basket.API.Mappers;
using Basket.API.Models;
using Basket.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers;

public class DiscountController : ApiController
{
    public DiscountController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetPriceWithCoupon([FromQuery] ApplyCouponApiModel model, CancellationToken token)
    {
        var command = new ApplyCouponQuery
        {
            UserName = model.UserName,
            Code = model.Code
        };

        var result = await _mediator.Send(command, token);

        var apiResult = ApiBasketMapper.Mapper.Map<CouponApplicationApiResponse>(result);

        return Ok(apiResult);
    }
}
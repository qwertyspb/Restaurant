using Catalog.API.Mappers;
using Catalog.API.Models;
using Catalog.Application.Commands;
using Catalog.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Catalog.Application.Helpers.SearchHelper;

namespace Catalog.API.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(Pagination<ProductApiModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetFilteredProducts([FromQuery] ApiSearchFilter request, CancellationToken token)
        {
            var filter = ApiCatalogMapper.Mapper.Map<SearchFilter>(request);

            var products = await _mediator.Send(new GetFilteredProductsQuery { SearchFilter = filter }, token);

            return Ok(ApiCatalogMapper.Mapper.Map<Pagination<ProductApiModel>>(products));
        }

        [HttpGet]
        [Route("[action]/{categoryId}")]
        [ProducesResponseType(typeof(List<ProductApiModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProductsByCategory(string categoryId, CancellationToken token)
        {
            var products = await _mediator.Send(new GetProductsByCategoryQuery { CategoryId = categoryId }, token);
            return Ok(ApiCatalogMapper.Mapper.Map<List<ProductApiModel>>(products));
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateProduct(CreateProductApiModel model, CancellationToken token)
        {
            var command = ApiCatalogMapper.Mapper.Map<CreateProductCommand>(model);
            await _mediator.Send(command, token);

            return Ok();
        }

        [HttpPatch]
        [Route("[action]")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct(UpdateProductApiModel model, CancellationToken token)
        {
            var command = ApiCatalogMapper.Mapper.Map<UpdateProductCommand>(model);
            await _mediator.Send(command, token);

            return Ok();
        }

        [HttpDelete]
        [Route("[action]/{productId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProduct(string productId, CancellationToken token)
        {
            await _mediator.Send(new DeleteProductCommand { ProductId = productId }, token);
            return Ok();
        }
    }
}

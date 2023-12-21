using System.Net;
using Catalog.API.Mappers;
using Catalog.API.Models;
using Catalog.Application.Commands;
using Catalog.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    public class CatalogController : ApiController
    {
        private readonly IMediator _mediator;

        public CatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(List<ProductApiModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllProducts(CancellationToken token)
        {
            var products = await _mediator.Send(new GetAllProductsQuery(),  token);
            return Ok(ApiCatalogMapper.Mapper.Map<List<ProductApiModel>>(products));
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(List<CategoryApiModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllCategories(CancellationToken token)
        {
            var categories = await _mediator.Send(new GetAllCategoriesQuery(), token);
            return Ok(ApiCatalogMapper.Mapper.Map<List<CategoryApiModel>>(categories));
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
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductApiModel model, CancellationToken token)
        {
            var command = ApiCatalogMapper.Mapper.Map<CreateProductCommand>(model);
            await _mediator.Send(command, token);

            return Ok();
        }

        [HttpPatch]
        [Route("[action]")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductApiModel model, CancellationToken token)
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

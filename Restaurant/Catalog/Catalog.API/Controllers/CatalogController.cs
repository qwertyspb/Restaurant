using Catalog.API.Mappers;
using Catalog.API.Models;
using Catalog.Application.Commands;
using Catalog.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        public async Task<IActionResult> GetFilteredProducts(CancellationToken token)
        {
            var products = await _mediator.Send(new GetFilteredProductsQuery(),  token);
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
        [Route("[action]")]
        [ProducesResponseType(typeof(CategoryApiModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCategoryByName(string categoryName, CancellationToken token)
        {
            var result = await _mediator.Send(new GetCategoryByNameQuery { Name = categoryName }, token);
            return Ok(ApiCatalogMapper.Mapper.Map<CategoryApiModel>(result));
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

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateCategory(CreateCategoryApiModel model, CancellationToken token)
        {
            var command = ApiCatalogMapper.Mapper.Map<CreateCategoryCommand>(model);
            await _mediator.Send(command, token);

            return Ok();
        }

        [HttpPatch]
        [Route("[action]")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateProductApiModel model, CancellationToken token)
        {
            var command = ApiCatalogMapper.Mapper.Map<UpdateCategoryCommand>(model);
            await _mediator.Send(command, token);

            return Ok();
        }

        [HttpDelete]
        [Route("[action]/{categoryId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCategory(string categoryId, CancellationToken token)
        {
            await _mediator.Send(new DeleteCategoryCommand { CategoryId = categoryId }, token);
            return Ok();
        }
    }
}

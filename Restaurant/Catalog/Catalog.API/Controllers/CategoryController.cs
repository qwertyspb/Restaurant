using Catalog.API.Mappers;
using Catalog.API.Models;
using Catalog.Application.Commands;
using Catalog.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
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
        public async Task<IActionResult> UpdateCategory(UpdateCategoryApiModel model, CancellationToken token)
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

using MediatR;

namespace Catalog.Application.Commands
{
    public class CreateCategoryCommand : IRequest
    {
        public string Name { get; set; }
    }
}

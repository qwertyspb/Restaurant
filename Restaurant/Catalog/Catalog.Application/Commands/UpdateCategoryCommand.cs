using MediatR;

namespace Catalog.Application.Commands
{
    public class UpdateCategoryCommand : IRequest
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
    }
}

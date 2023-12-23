using MediatR;

namespace Catalog.Application.Commands
{
    public class DeleteCategoryCommand : IRequest
    {
        public string CategoryId { get; set; }
    }
}

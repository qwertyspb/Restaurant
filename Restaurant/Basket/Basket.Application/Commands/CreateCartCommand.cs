using Basket.Application.Responses;
using MediatR;

namespace Basket.Application.Commands;

public class CreateCartCommand : UserNameBasedRequest, IRequest<CreateCartResponse>
{
    public int VisitorsAmount { get; set; }
    public DateTime BookingStartDate { get; set; }
    public TimeSpan BookingDuration { get; set; }
}
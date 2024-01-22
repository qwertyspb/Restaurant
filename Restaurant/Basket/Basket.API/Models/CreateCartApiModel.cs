namespace Basket.API.Models;

public class CreateCartApiModel
{
    public string UserName { get; set; }
    public int VisitorsAmount { get; set; }
    public DateTime BookingStartDate { get; set; }
    public int BookingDurationInHours { get; set; }
}
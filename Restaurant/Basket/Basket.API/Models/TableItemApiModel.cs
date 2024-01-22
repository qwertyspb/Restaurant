namespace Basket.API.Models;

public class TableItemApiModel
{
    public int VisitorsAmount { get; set; }
    public DateTime BookingStartDate { get; set; }
    public TimeSpan BookingDuration { get; set; }
}
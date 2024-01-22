namespace Basket.Core.Entities;

public class TableItem
{
    public string TableId { get; set; }
    public int VisitorsAmount { get; set; }
    public DateTime BookingStartDate { get; set; }
    public TimeSpan BookingDuration { get; set; }
}
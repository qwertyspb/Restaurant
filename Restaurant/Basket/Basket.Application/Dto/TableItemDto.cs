namespace Basket.Application.Dto;

public class TableItemDto
{
    public string TableId { get; set; }
    public int VisitorsAmount { get; set; }
    public DateTime BookingStartDate { get; set; }
    public TimeSpan BookingDuration { get; set; }
}
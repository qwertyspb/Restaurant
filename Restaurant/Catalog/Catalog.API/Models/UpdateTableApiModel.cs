namespace Catalog.API.Models;

public class UpdateTableApiModel
{
    public string TableId { get; set; } 
    public int Amount { get; set; }
    public int Capacity { get; set; }
}
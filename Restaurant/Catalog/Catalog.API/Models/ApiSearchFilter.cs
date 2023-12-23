namespace Catalog.API.Models
{
    public class ApiSearchFilter
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string? CategoryId { get; set; }
        public string? Sorting { get; set; }
        public string? Search { get; set; }
    }
}

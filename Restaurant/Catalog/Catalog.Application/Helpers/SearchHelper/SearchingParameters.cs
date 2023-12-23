namespace Catalog.Application.Helpers.SearchHelper
{
    public class SearchingParameters
    {
        private const int MaxPageSize = 70;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        
        public string CategoryId { get; set; }
        public string Sorting { get; set; }
        public string Search { get; set; }
    }
}

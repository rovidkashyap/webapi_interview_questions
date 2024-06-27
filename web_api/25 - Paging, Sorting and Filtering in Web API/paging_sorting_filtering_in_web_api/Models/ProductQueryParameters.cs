namespace paging_sorting_filtering_in_web_api.Models
{
    public class ProductQueryParameters
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string SortBy { get; set; } = "Name";
        public string SortOrder { get; set; } = "asc"; // or "desc"
        public string Filter { get; set; }
        public string Category { get; set; }
    }
}

using EventCatalogAPI.Domain;

namespace EventCatalogAPI.ViewModels
{
    public class PaginatedItemsViewModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long Count { get; set; }
        public IEnumerable<Event> Data { get; set; }
    }
}

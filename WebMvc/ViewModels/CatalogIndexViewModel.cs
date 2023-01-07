using Microsoft.AspNetCore.Mvc.Rendering;
using WebMvc.Models;

namespace WebMvc.ViewModels
{
    public class CatalogIndexViewModel
    {
        public IEnumerable<SelectListItem> Organizers { get; set; }
        public IEnumerable<SelectListItem> Categories{ get; set; }
        public IEnumerable<Event> Events { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
        public int? OrganizerFilterApplied { get; set; }
        public int? CategoryFilterApplied { get; set; }
    }
}

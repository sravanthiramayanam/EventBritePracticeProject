using Microsoft.AspNetCore.Mvc.Rendering;
using WebMvc.Models;

namespace WebMvc.Services
{
    public interface ICatalogService
    {
        Task<EventCatalog> GetEventsAsync(int page, int size, int? organizer, int? category);
        Task<IEnumerable<SelectListItem>> GetEventOrganizersAsync();
        Task<IEnumerable<SelectListItem>> GetCategoriesAsync();
    }
}

using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class EventCatalogController : Controller
    {
        private readonly ICatalogService _service;
        public EventCatalogController(ICatalogService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(int? page,int? organizerFilterApplied,int? categoryFilterApplied )
        {
            var itemsOnPage = 10;
            var eventCatalog= await _service.GetEventsAsync (page ?? 0, itemsOnPage,organizerFilterApplied,categoryFilterApplied);
            //var event = await _service.GetEventItemsAsync (page ?? 0, itemsOnPage);
            var vm = new CatalogIndexViewModel
            {
                Organizers = await _service.GetEventOrganizersAsync(),
                Categories = await _service.GetCategoriesAsync(),
                Events = eventCatalog.Data,
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = eventCatalog.PageIndex,
                    TotalItems = eventCatalog.Count,
                    ItemsPerPage = eventCatalog.PageSize,
                    TotalPages = (int)Math.Ceiling((decimal)eventCatalog.Count / itemsOnPage)
                },
                OrganizerFilterApplied = organizerFilterApplied,
                CategoryFilterApplied = categoryFilterApplied

            };
            return View(vm);
        }
    }
}

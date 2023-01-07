using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using EventCatalogAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventCatalogAPI.Controllers
{
   [Route("api/[controller]")]
    [ApiController]
    public class EventCatalogController : ControllerBase
    {
      private readonly CatalogContext _context;
      private readonly IConfiguration _config;
      public EventCatalogController(CatalogContext context,IConfiguration config)
      {
        _context= context;
        _config= config;
      }
      [HttpGet("[action]")]
      public async Task<IActionResult> Categories()
      {
           var types = await _context.Categories.ToListAsync();
           return Ok(types);
      }
        [HttpGet("[action]")]
        public async Task<IActionResult> EventOrganizers()
        {
            var  eventOrganizers= await _context.EventOrganizers.ToListAsync();
            return Ok(eventOrganizers);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Events(
            [FromQuery]int pageIndex = 0,[FromQuery]int pageSize = 2)
        {
            var itemsCount = _context.Events.LongCountAsync();
            var items= await _context.Events.OrderBy( c => c.Name)
                                           .Skip(pageIndex*pageSize)
                                           .Take(pageSize)
                                            .ToListAsync();
            items = ChangePictureUrl(items);
            var model = new PaginatedItemsViewModel
            {
                PageIndex = pageIndex,
                PageSize = items.Count(),
                Data = items,
                Count = itemsCount.Result
            };
            return Ok(model);

        }
        [HttpGet("[action]/filter")]
        public async Task<IActionResult> Events(
            [FromQuery] int? categoryId,
            [FromQuery]int? OrganizerId,
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 2)
        {
            var query =(IQueryable<Event>) _context.Events;
            if(categoryId.HasValue)
            {
                query = query.Where(c => c.CategoryId == categoryId.Value);
            }
            if(OrganizerId.HasValue)
            {
                query = query.Where((c) => c.OrganizerId == OrganizerId.Value);
            }
            var itemsCount = query.LongCountAsync();
            var items = await query
                                 .OrderBy(c => c.Name)
                                 .Skip(pageIndex * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
            items = ChangePictureUrl(items);
            var model = new PaginatedItemsViewModel
            {
                PageIndex = pageIndex,
                PageSize = items.Count(),
                Data = items,
                Count = itemsCount.Result
            };
            return Ok(model);

        }
        private List<Event> ChangePictureUrl(List<Event> items)
        {
            items.ForEach(item => item.ImageUrl=item.ImageUrl
                                      .Replace("http://externalcatalogbaseurltobereplaced",
                                      _config["ExternalBaseUrl"]));
            return items;
            
        }
    }
}

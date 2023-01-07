using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebMvc.Infrastructure;
using WebMvc.Models;

namespace WebMvc.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly IHttpClient _httpClient;
        private readonly string _baseUrl;
        public CatalogService(IConfiguration config,IHttpClient client)
        {
            _httpClient = client;
            _baseUrl = $"{config["CatalogUrl"]}/api/EventCatalog";
        }
        public async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            var categoriesUri = APIPaths.EventCatalog.GetAllEventCategories(_baseUrl);
            var dataString = await _httpClient.GetStringAsync(categoriesUri);
            var items = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text="All",
                    Selected=true,
                }
            };
            var categories = JArray.Parse(dataString);
            foreach (var item in categories)
            {
                items.Add(new SelectListItem
                {
                    Value = item.Value<string>("id"),
                    Text = item.Value<string>("name")
                });
            }
            return items;
        }

        public async Task<EventCatalog> GetEventsAsync(int page, int size, int? organizer, int? category)
        {
           var eventItemsUri = APIPaths.EventCatalog.GetAllEvents(_baseUrl,page,size,organizer,category);//this line gets the url
           var dataString = await _httpClient.GetStringAsync(eventItemsUri);//pass url to get method.this line that goes request to microservice
           return JsonConvert.DeserializeObject<EventCatalog>(dataString);   //deserialize into model
           
        }

        public async Task<IEnumerable<SelectListItem>> GetEventOrganizersAsync()
        {
           var eventOrganizersUri =  APIPaths.EventCatalog.GetAllEventOrganizers(_baseUrl);
           var dataString = await _httpClient.GetStringAsync(eventOrganizersUri);
            var items = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text="All",
                    Selected=true,
                }
            };
            var eventOrganizers = JArray.Parse(dataString);
            foreach (var item in eventOrganizers)
            {
                items.Add(new SelectListItem
                {
                    Value = item.Value<string>("id"),
                    Text = item.Value<string>("name")
                });
            }
            return items;
        }
    }
}





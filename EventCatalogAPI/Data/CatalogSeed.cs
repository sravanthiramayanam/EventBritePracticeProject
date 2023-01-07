using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventCatalogAPI.Data
{
    public static class CatalogSeed
    {
        public  static void Seed(CatalogContext context)
        {
            context.Database.Migrate();//tables get created and set up migration by using this line.This is important
            if(!context.Categories.Any())
            {
                context.Categories.AddRange(GetCategories());
                context.SaveChanges();//after adding data its mandatory to save changes
            }
            if (!context.EventOrganizers.Any())
            {
                context.EventOrganizers.AddRange(GetEventOrganizers());
                context.SaveChanges();
            }
            if (!context.Events.Any())
            {
                context.Events.AddRange(GetEvents());
                context.SaveChanges();
            }
        }

        private static IEnumerable<Event> GetEvents()
        {
            return new List<Event>()
            {
                new Event{CategoryId = 1 ,
                          OrganizerId = 1 ,
                          Name = "Kids Winter Concert", 
                          Description = "2023 Season Winter concert for kids ages 8-13" ,
                          Price = 22.50 ,
                          LocationAddress = "1213 Disneyland Dr",
                          City = "Anaheim" ,
                          State = "CA" ,
                          ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" ,
                          Recurring="daily",
                          EventDuration = 45,
                          TicketsAvailable = 20 } ,
                new Event{CategoryId = 2 ,
                           OrganizerId = 2 ,
                           Name = "Real Estate and Investment",
                          Description = "Getting ideas and plan for future investments" ,
                          Price = 15.50 ,
                          LocationAddress = "Seattle Center",
                          City = "Seattle" ,
                          State = "WA" ,
                          ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2" ,
                          EventStartDateTime=new DateTime(2022,11,21,8,30,30),
                          EventEndDateTime= new DateTime(2022,12,21,9,30,0),
                          Recurring="2 days",
                          EventDuration = 4,
                          TicketsAvailable = 25 } ,
                new Event{CategoryId = 3 ,
                          OrganizerId = 3 ,
                          Name = "Art classes",
                          Description = "Online art classes for kids to learn abstract painting" ,
                          Price = 0 ,
                          LocationAddress = "Art for kids hub",
                          City = "Austin" ,
                          State = "Texas" ,
                          ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3" ,
                          Recurring="Every Saturday",
                          EventDuration = 1,
                          TicketsAvailable = 25 } ,

                new Event{ CategoryId = 3 ,
                          OrganizerId = 1 ,
                          Name = "Enchanted disney show",
                          Description = "Experience the disney characters live and performing" ,
                          Price = 0 ,
                          LocationAddress = "Renton",
                          City = "Renton" ,
                          State = "WA" ,
                          ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4" ,
                          Recurring="sunday",
                          EventDuration = 1,
                          TicketsAvailable = 25 } ,
            };
        }

        private static IEnumerable<EventOrganizer> GetEventOrganizers()
        {
            return new List<EventOrganizer>()
           {
               new EventOrganizer{Name="Disney"},
               new EventOrganizer{Name="Seattle Expo"},
               new EventOrganizer{Name="Theater Arts"}
           };
        }

        private static IEnumerable<Category> GetCategories()
        {
            return new List<Category>()
           {
               new Category{Name="Music"},
               new Category{Name="Business"},
               new Category{Name="Performing & Visual Arts"}
           };
        }

    }
}

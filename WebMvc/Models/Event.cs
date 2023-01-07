namespace WebMvc.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string LocationAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string ImageUrl { get; set; }
        public DateTime EventStartDateTime { get; set; }
        public DateTime EventEndDateTime { get; set; }
        //public DateTime EventStartTime { get; set; }
        //public DateTime EventEndTime { get; set; }
        public string Recurring { get; set; }
        public int EventDuration { get; set; }
        public int TicketsAvailable { get; set; }

        public int CategoryId { get; set; }
        public int OrganizerId { get; set; }

        public string Category { get; set; }
        public string EventOrganizer { get; set; }
    }
}

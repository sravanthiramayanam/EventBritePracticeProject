namespace WebMvc.Infrastructure
{
    public static class APIPaths
    {
        public static class EventCatalog
        {
            public static string GetAllEventCategories(string baseUri)
            {
                return $"{baseUri}/categories";
            }
            public static string GetAllEventOrganizers(string baseUri)
            {
                return $"{baseUri}/eventorganizers";
            }

            public static string GetAllEvents(string baseUri, 
                                        int page,
                                        int take,
                                        int? organizer,int? category)
            {
                var preUri = string.Empty;
                var filterQs = string.Empty;
                if (organizer.HasValue)
                {
                    filterQs = $"organizerId={organizer.Value}";
                }
                if (category.HasValue)
                {
                    filterQs = (filterQs == string.Empty) ? $"categoryId={category.Value}" :
                        $"{filterQs}&categoryId={category.Value}";
                }
                if (string.IsNullOrEmpty(filterQs))
                {
                    preUri = $"{baseUri}/events?pageIndex={page}&pageSize={take}";
                }
                else
                {
                    preUri = $"{baseUri}/events/filter?pageIndex={page}&pageSize={take}&{filterQs}";
                }
                return preUri ;
            }


        }

    }
}

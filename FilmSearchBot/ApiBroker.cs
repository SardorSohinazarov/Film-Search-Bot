using Newtonsoft.Json;

namespace FilmSearchBot
{
    public class ApiBroker
    {
        public static async Task<ListOfSearch> GetFilmListAsync(string name, int pageNumber = 1)
        {
            if (pageNumber <= 1)
                pageNumber = 1;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://www.omdbapi.com/");
            var json = await client.GetStringAsync($"?apikey=8590bdaf&s={name}&page={pageNumber}");
            var root = JsonConvert.DeserializeObject<ListOfSearch>(json);

            root.PageNumber = pageNumber;

            if (pageNumber <= 1)
                root.PageNumber = 1;

            root.SearchKey = name;

            return root;
        }

        public static async Task<Film> GetFilmAsync(string imdbID)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://www.omdbapi.com/");
            var json = await client.GetStringAsync($"?apikey=8590bdaf&i={imdbID}");
            var film = JsonConvert.DeserializeObject<Film>(json);
            return film;
        }
    }

    public class Film
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
    }

    public class ListOfSearch
    {
        public List<Search> Search { get; set; }
        public string totalResults { get; set; }
        public string Response { get; set; }
        public int? PageNumber { get; set; }
        public string? SearchKey { get; set; }
    }

    public class Search
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }
}

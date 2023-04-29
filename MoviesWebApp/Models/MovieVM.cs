using Microsoft.AspNetCore.Mvc.Rendering;

namespace MoviesWebApp.Models
{
    public class MovieVM
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<int> selectedGenres { get; set; }
        public SelectList GenreSelectList { get; set; }

    }
}

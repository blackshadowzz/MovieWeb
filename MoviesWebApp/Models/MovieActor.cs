using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace MoviesWebApp.Models
{
    public class MovieActor
    {
        public Guid? ActorId { get; set; }
        public Guid? MovieId { get; set; }

        [ForeignKey("MovieId")]
        public Movie? Movie { get; set; }
        [ForeignKey("ActorId")]
        public Actor? Actor { get; set; }
    }
}

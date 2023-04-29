using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Models;

namespace MoviesWebApp.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
           
        }
       
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<UserRegister> UserRegisters { get; set; }

        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieDirector> MovieDirectors { get; set; }
        public DbSet<MovieStudio> MovieStudios { get; set; }
        public DbSet<MovieCountry> MovieCountries { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure composite keys
            modelBuilder.Entity<MovieActor>()
              .HasKey(ma => new { ma.MovieId, ma.ActorId });

            modelBuilder.Entity<MovieDirector>()
              .HasKey(md => new { md.MovieId, md.DirectorId });

            modelBuilder.Entity<MovieGenre>()
              .HasKey(mg => new { mg.MovieId, mg.GenreId });

            modelBuilder.Entity<MovieCountry>()
             .HasKey(mc => new { mc.MovieId, mc.CountryId });

            modelBuilder.Entity<MovieStudio>()
             .HasKey(ms => new { ms.MovieId, ms.StudioId });

            // Configure many-to-many relationships
            modelBuilder.Entity<MovieActor>()
              .HasOne(ma => ma.Movie)
              .WithMany(m => m.MovieActors)
              .HasForeignKey(ma => ma.MovieId);

            modelBuilder.Entity<MovieActor>()
              .HasOne(ma => ma.Actor)
              .WithMany(a => a.MovieActors)
              .HasForeignKey(ma => ma.ActorId);

            modelBuilder.Entity<MovieDirector>()
              .HasOne(md => md.Movie)
              .WithMany(m => m.MovieDirectors)
              .HasForeignKey(md => md.MovieId);

            modelBuilder.Entity<MovieDirector>()
              .HasOne(md => md.Director)
              .WithMany(d => d.MovieDirectors)
              .HasForeignKey(md => md.DirectorId);

            modelBuilder.Entity<MovieGenre>()
              .HasOne(mg => mg.Movie)
              .WithMany(m => m.MovieGenres)
              .HasForeignKey(mg => mg.MovieId);

            modelBuilder.Entity<MovieGenre>()
              .HasOne(mg => mg.Genre)
              .WithMany(g => g.MovieGenres)
              .HasForeignKey(mg => mg.GenreId);

            modelBuilder.Entity<MovieCountry>()
             .HasOne(mc => mc.Movie)
             .WithMany(m => m.MovieCountries)
             .HasForeignKey(mc => mc.MovieId);

            modelBuilder.Entity<MovieCountry>()
              .HasOne(mc => mc.Country)
              .WithMany(c => c.MovieCountries)
              .HasForeignKey(mc => mc.CountryId);

            modelBuilder.Entity<MovieStudio>()
             .HasOne(ms => ms.Movie)
             .WithMany(m => m.MovieStudios)
             .HasForeignKey(ms => ms.MovieId);

            modelBuilder.Entity<MovieStudio>()
             .HasOne(ms => ms.Studio)
             .WithMany(c => c.MovieStudios)
             .HasForeignKey(ms => ms.StudioId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

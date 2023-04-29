using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Data;
using MoviesWebApp.Models;

namespace MoviesWebApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public MoviesController(MovieDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var movies = _context.Movies.Include(g => g.MovieGenres).ThenInclude(mg => mg.Genre);
            return View(await movies.ToListAsync());
        }


        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(a=>a.MovieActors).ThenInclude(a=>a.Actor)
                .Include(a => a.MovieDirectors).ThenInclude(a => a.Director)
                .Include(a => a.MovieGenres).ThenInclude(a => a.Genre)
                .Include(a => a.MovieStudios).ThenInclude(a => a.Studio)
                .Include(a => a.MovieCountries).ThenInclude(a => a.Country)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        public IActionResult Create()
        {
            PopulateGenres();
            PopulateStudios();
            PopulateActors();
            PopulateCoutries();
            PopulateDirectos();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Movie movie, int[] selectedGenres, Guid[] selectedActors,
                                                    Guid[] selectedDirectors, int[] selectedStudios,
                                                    int[] selectedCountries)
        {
            if (ModelState.IsValid)
            {
                movie.MovieId = Guid.NewGuid();
                string fileFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                string fileName = Guid.NewGuid().ToString() + "_" + movie.FrontImage.FileName;
                string backfile = Guid.NewGuid().ToString() + "_" + movie.BackImage.FileName;
                string filePath = Path.Combine(fileFolder, fileName);
                string filePath2 = Path.Combine(fileFolder, backfile);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    movie.FrontImage.CopyTo(fileStream);
                }
                using (var fileStream2 = new FileStream(filePath2, FileMode.Create))
                {
                    movie.BackImage.CopyTo(fileStream2);
                }
                movie.CoverImage = fileName;
                movie.BackCoverImage = backfile;
                _context.Add(movie);

                foreach (var i in selectedGenres)
                {
                    var mov = new MovieGenre();
                    mov.MovieId = movie.MovieId;
                    mov.GenreId = i;
                    _context.Add(mov);
                }
                foreach (var i in selectedActors)
                {
                    var act = new MovieActor();
                    act.MovieId = movie.MovieId;
                    act.ActorId = i;
                    _context.Add(act);
                }
                foreach (var i in selectedDirectors)
                {
                    var dir = new MovieDirector();
                    dir.MovieId = movie.MovieId;
                    dir.DirectorId = i;
                    _context.Add(dir);
                }
                foreach (var i in selectedStudios)
                {
                    var stu = new MovieStudio();
                    stu.MovieId = movie.MovieId;
                    stu.StudioId = i;
                    _context.Add(stu);
                }
                foreach (var i in selectedCountries)
                {
                    var cou = new MovieCountry();
                    cou.MovieId = movie.MovieId;
                    cou.CountryId = i;
                    _context.Add(cou);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateGenres();
            PopulateStudios();
            PopulateActors();
            PopulateCoutries();
            PopulateDirectos();
            return View(movie);
        }

        private void PopulateGenres(int[] selectedValues = null)
        {
            var genres = _context.Genres.OrderBy(g => g.GenreName).ToList();
            ViewBag.Genres = new MultiSelectList(genres, "GenreID", "GenreName", selectedValues);
        }
        private void PopulateStudios(int[] selectedValues = null)
        {
            var studios = _context.Studios.OrderBy(g => g.Name).ToList();
            ViewBag.Studios = new MultiSelectList(studios, "StudioId", "Name", selectedValues);
        }
        private void PopulateActors(int[] selectedValues = null)
        {
            var actors = _context.Actors.OrderBy(g => g.FirstName).ToList();
            ViewBag.Actors = new MultiSelectList(actors, "ActorID", "FirstName", selectedValues);
        }
        private void PopulateDirectos(int[] selectedValues = null)
        {
            var directors = _context.Directors.OrderBy(g => g.FirstName).ToList();
            ViewBag.Directors = new MultiSelectList(directors, "DirectorID", "FirstName", selectedValues);
        }

        private void PopulateCoutries(int[] selectedValues = null)
        {
            var countries = _context.Countries.OrderBy(g => g.CountryName).ToList();
            ViewBag.Countries = new MultiSelectList(countries, "CountryID", "CountryName", selectedValues);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            PopulateGenres();
            //PopulateStudios();
            //PopulateActors();
            //PopulateCoutries();
            //PopulateDirectos();

            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }



            var movie = await _context.Movies.Include(g=>g.MovieGenres)
                .FirstOrDefaultAsync(m=>m.MovieId==id);
            if (movie == null)
            {
                return NotFound();
            }
            var mv = new MovieVM
            {
                Movie=movie,
                Genres= await _context.Genres.ToListAsync()
            };
            PopSelectedLists(mv);
            return View(mv);
        }
        public void PopSelectedLists(MovieVM movieVM)
        {
            movieVM.Genres = _context.Genres.ToList();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Movie movie)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {

            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(Guid id)
        {
          return (_context.Movies?.Any(e => e.MovieId == id)).GetValueOrDefault();
        }
    }
}

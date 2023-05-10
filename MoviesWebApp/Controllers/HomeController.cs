using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Data;
using MoviesWebApp.Models;
using System.Diagnostics;

namespace MoviesWebApp.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly MovieDbContext _context;

        public HomeController(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var movies = _context.Movies
                .Include(g => g.MovieGenres)
                .ThenInclude(mg => mg.Genre);
            return View(await movies.ToListAsync());
        }
        public async Task<IActionResult> Details(Guid? id)
        {

            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(a => a.MovieActors).ThenInclude(a => a.Actor)
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


    }
}
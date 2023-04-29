using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Data;
using MoviesWebApp.Models;
using System.Diagnostics;

namespace MoviesWebApp.Controllers
{
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

       
    }
}
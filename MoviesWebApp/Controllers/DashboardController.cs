using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Data;

namespace MoviesWebApp.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly MovieDbContext _dbContext;

        public DashboardController(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var movies = _dbContext.Movies
              .Include(g => g.MovieGenres)
              .ThenInclude(mg => mg.Genre);
            return View(await movies.ToListAsync());
        }
    }
}

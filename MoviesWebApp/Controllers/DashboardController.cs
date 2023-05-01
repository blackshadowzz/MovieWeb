using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            //var gets=_dbContext
            return View();
        }
    }
}

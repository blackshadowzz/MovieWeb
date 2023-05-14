using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Data;
using MoviesWebApp.Models;

namespace MoviesWebApp.Controllers
{
    public class ActorsController : Controller
    {
        private readonly MovieDbContext _context;

        public ActorsController(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return _context.Actors != null ? 
                          View(await _context.Actors.ToListAsync()) :
                          Problem("Entity set 'MovieDbContext.Actors'  is null.");
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Actors == null)
            {
                return NotFound();
            }

            var actor = await _context.Actors
                .FirstOrDefaultAsync(m => m.ActorID == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActorID,FirstName,LastName,Gender,DateOfBirth,Phone,Email,Role,Address,Description")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                actor.ActorID = Guid.NewGuid();
                _context.Add(actor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Actors == null)
            {
                return NotFound();
            }

            var actor = await _context.Actors.FindAsync(id);
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ActorID,FirstName,LastName,Gender,DateOfBirth,Phone,Email,Role,Address,Description")] Actor actor)
        {
            if (id != actor.ActorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorExists(actor.ActorID))
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
            return View(actor);
        }
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Actors == null)
            {
                return NotFound();
            }

            var actor = await _context.Actors
                .FirstOrDefaultAsync(m => m.ActorID == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Actors == null)
            {
                return Problem("Entity set 'MovieDbContext.Actors'  is null.");
            }
            var actor = await _context.Actors.FindAsync(id);
            if (actor != null)
            {
                _context.Actors.Remove(actor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorExists(Guid id)
        {
          return (_context.Actors?.Any(e => e.ActorID == id)).GetValueOrDefault();
        }
    }
}

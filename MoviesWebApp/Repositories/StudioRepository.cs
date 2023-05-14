using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MoviesWebApp.Data;
using MoviesWebApp.Models;

namespace MoviesWebApp.Repositories
{
    public class StudioRepository : IStudioRepository
    {
        private readonly MovieDbContext _context;
        public StudioRepository(MovieDbContext context)
        {
            _context = context;
        }
        public void DeleteStudio(int id)
        {
            Studio? studio=_context.Studios.Find(id);
            if (studio != null)
            {
                _context.Studios.Remove(studio);
            }

        }

        public IEnumerable<Studio> GetAll()
        {
            return _context.Studios.ToList();
        }

        public Studio GetId(int id)
        {
            return _context.Studios.Find(id);
        }

        public void NewStudio(Studio studio)
        {
            _context.Studios.Add(studio);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateStudio(Studio studio)
        {
            _context.Entry(studio).State=EntityState.Modified;
        }
    }
}

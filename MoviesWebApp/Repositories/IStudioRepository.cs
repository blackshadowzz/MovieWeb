using MoviesWebApp.Models;

namespace MoviesWebApp.Repositories
{
    public interface IStudioRepository
    {
        IEnumerable<Studio> GetAll();
        Studio GetId (int id);
        void NewStudio (Studio studio);
        void UpdateStudio (Studio studio);  
        void DeleteStudio (int id);
        void Save();
    }
}

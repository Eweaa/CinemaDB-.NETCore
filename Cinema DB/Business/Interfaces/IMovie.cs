
using Cinema_DB.Domain.Entities;

namespace Cinema_DB.Business.Interfaces
{
    public interface IMovie
    {
        ICollection<Movie> GetMovies();
        Movie GetMovie(int Id);
        bool MovieExists(int Id);
        bool Save();
    }
}

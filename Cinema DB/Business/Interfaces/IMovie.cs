using Cinema_DB.Data.Models;

namespace Cinema_DB.Business.Interfaces
{
    public interface IMovie
    {
        ICollection<Movie> GetMovies();
        Movie GetMovie(int Id);
        bool MovieExists(int Id);
        bool CreateMovie(Movie movie);
        bool Save();
    }
}

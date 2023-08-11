using Cinema_DB.Business.Interfaces;
using Cinema_DB.Data;
using Cinema_DB.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema_DB.Business.Repos
{
    public class MovieRepo : IMovie
    {
        private readonly DataContext _context;
        public MovieRepo(DataContext context) => _context = context;

        public Movie GetMovie(int Id) => _context.Movies
            .Where(A => A.Id == Id)
            .Include(d => d.Director)
            .FirstOrDefault();
        public ICollection<Movie> GetMovies() => _context.Movies.Include(d => d.Director).ToList();

        public bool CreateMovie(Movie movie)
        {
            _context.Add(movie);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool MovieExists(int Id) => _context.Movies.Where(A => A.Id != Id).Any();
    }
}

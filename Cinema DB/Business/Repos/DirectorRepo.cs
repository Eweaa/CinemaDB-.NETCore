using Cinema_DB.Business.Interfaces;
using Cinema_DB.Domain.Entities;
using Cinema_DB.Infrastructure.Persistence;

namespace Cinema_DB.Business.Repos
{
    public class DirectorRepo : IDirector
    {
        private readonly DataContext _context;
        public DirectorRepo(DataContext context)
        {
            _context = context;
        }

        public bool CreateDirector(Director director)
        {
            throw new NotImplementedException();
        }

        public bool DirectorExists(int Id) => _context.Directors.Where(D => D.Id ==Id).Any();

        public Director GetDirector(int Id) => _context.Directors.Where(D => D.Id == Id).FirstOrDefault();

        public ICollection<Director> GetDirectors() => _context.Directors.ToList();

        public bool Save()
        {
            throw new NotImplementedException();
        }
    }
}

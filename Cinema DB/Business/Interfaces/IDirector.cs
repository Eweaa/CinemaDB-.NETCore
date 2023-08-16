using Cinema_DB.Domain.Entities;

namespace Cinema_DB.Business.Interfaces
{
    public interface IDirector
    {
        ICollection<Director> GetDirectors();
        Director GetDirector(int Id);
        bool DirectorExists(int Id);
        bool CreateDirector(Director director);
        bool Save();
    }
}

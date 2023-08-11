using Cinema_DB.Data.Models;

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

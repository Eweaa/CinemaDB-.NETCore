using Cinema_DB.Domain.Common;

namespace Cinema_DB.Domain.Entities
{
    public class Director : BaseEntity
    {
        public ICollection<Movie> Movies { get; } = new List<Movie>();
    }
}

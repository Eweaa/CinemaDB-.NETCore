using Cinema_DB.Domain.Common;

namespace Cinema_DB.Domain.Entities
{
    public class Actor : BaseEntity
    {
        public List<Movie> Movies { get; } = new();
    }
}

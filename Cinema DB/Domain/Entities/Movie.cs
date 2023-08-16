using Cinema_DB.Domain.Common;

namespace Cinema_DB.Domain.Entities
{
    public class Movie : BaseEntity
    {
        public long DirectorId { get; set; }
        public Director Director { get; set; }
        public List<Actor> Actors { get; set; }
    }
}

using Cinema_DB.Domain.Entities;

namespace Cinema_DB.Application.Movies.Queries
{
    public class MovieDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long DirectorId { get; set; }
        public string DirectorName { get; set; }
    }
}

using Cinema_DB.Application.Movies.Queries;
using Cinema_DB.Domain.Entities;

namespace Cinema_DB.Application.ActorsNS.Queries
{
    public class ActorDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<MovieDto> Movies { get; set; }
    }
}

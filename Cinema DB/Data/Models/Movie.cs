namespace Cinema_DB.Data.Models
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public long DirectorId { get; set; }
        public Director Director { get; set; }
        public List<Actor> Actors { get; } = new();
        //public DateTime ReleaseDate { get; set; }
    }
}

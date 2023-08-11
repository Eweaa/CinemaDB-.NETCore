namespace Cinema_DB.Data.Models
{
    public class Director : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; } = new List<Movie>();
    }
}

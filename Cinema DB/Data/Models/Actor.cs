using System.ComponentModel.DataAnnotations;

namespace Cinema_DB.Data.Models
{
    public class Actor : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        //public DateTime BirthDate { get; set; }
        public List<Movie> Movies { get; } = new();
    }
}

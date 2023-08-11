using System.ComponentModel.DataAnnotations;

namespace Cinema_DB.Data.Models
{
    public class BaseEntity
    {
        [Required]
        public long Id { get; set; }
    }
}

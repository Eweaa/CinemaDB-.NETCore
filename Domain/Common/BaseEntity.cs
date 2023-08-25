using System.ComponentModel.DataAnnotations;

namespace Cinema_DB.Domain.Common
{
    public abstract class BaseEntity
    {
        [Required] public long Id { get; set; }
        [Required] public string Name { get; set; }
    }
}

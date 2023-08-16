using Cinema_DB.Domain.Common;

namespace Cinema_DB.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Password { get; set; }
        public bool Role { get; set; }
    }
}

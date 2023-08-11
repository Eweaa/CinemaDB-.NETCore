namespace Cinema_DB.Data.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public bool Role { get; set; }
    }
}

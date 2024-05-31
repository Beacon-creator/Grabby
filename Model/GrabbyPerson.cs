using SQLite;

namespace Grabby_Two.Model
{
    public class GrabbyPerson
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        public string? Full_name { get; set; }
        public string? Email { get; set; }

        public string? Password { get; set; }

        public bool Subscribed { get; set; }
        public int Age { get; set; }
    }
}

using SQLite;

namespace TPCWare.SQLiteTest.Model
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

    }
}



using SQLite;

namespace TPCWare.SQLiteTest.Model
{
    [Table("Campuses")]
    public class Campuses
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

    }
}



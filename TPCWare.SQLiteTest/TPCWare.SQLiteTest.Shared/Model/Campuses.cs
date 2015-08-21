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

        public string WebsiteLink { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

    }
}



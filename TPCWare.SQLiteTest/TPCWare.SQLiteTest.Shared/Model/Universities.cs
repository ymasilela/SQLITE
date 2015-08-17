using SQLite;

namespace TPCWare.SQLiteTest.Model
{
    [Table("Universities")]
    public class Universities
    {
        [PrimaryKey, AutoIncrement]
        public int U_Id { get; set; }

        public string Name { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

    }
}




using SQLite;

namespace TPCWare.SQLiteTest.Model
{
    [Table("Universities")]
    public class Universities
    {


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }


    }
}



